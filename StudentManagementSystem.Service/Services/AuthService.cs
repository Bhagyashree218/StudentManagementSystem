using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Contracts.Response;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Repository.Interfaces;
using StudentManagementSystem.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentManagementSystem.Service.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly IUserRepository _userRepository;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        IConfiguration config,
        IUserRepository userRepository,
        ILogger<AuthService> logger)
    {
        _config = config;
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task RegisterAsync(RegisterUserRequestDto request)
    {
        _logger.LogInformation("Register attempt for username: {Username}", request.Username);

        var existingUser = await _userRepository.GetByUsernameAsync(request.Username);

        if (existingUser != null)
        {
            _logger.LogWarning("User already exists: {Username}", request.Username);
            throw new InvalidOperationException("User already exists");
        }

        var user = new User
        {
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = "Admin"
        };

        await _userRepository.AddAsync(user);

        _logger.LogInformation("User registered successfully: {Username}", request.Username);
    }

    public async Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        _logger.LogInformation("Login attempt for username: {Username}", request.Username);

        var user = await _userRepository.GetByUsernameAsync(request.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            _logger.LogWarning("Invalid login attempt for username: {Username}", request.Username);
            throw new UnauthorizedAccessException("Invalid credentials");
        }

        _logger.LogInformation("Login successful for username: {Username}", request.Username);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                Convert.ToDouble(_config["Jwt:DurationInMinutes"])),
            signingCredentials: creds
        );

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token)
        };
    }
}
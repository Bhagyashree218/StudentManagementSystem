using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Contracts.Response;

namespace StudentManagementSystem.Service.Interfaces;

public interface IAuthService
{
    Task<LoginResponse> LoginAsync(LoginRequest request);
}
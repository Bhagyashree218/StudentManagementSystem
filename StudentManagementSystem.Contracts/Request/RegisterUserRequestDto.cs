namespace StudentManagementSystem.Contracts.Request
{
    public class RegisterUserRequestDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

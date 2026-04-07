using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Repository.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task AddAsync(User user);
}
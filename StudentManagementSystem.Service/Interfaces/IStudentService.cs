using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Contracts.Response;

namespace StudentManagementSystem.Service.Interfaces;

public interface IStudentService
{
    Task<List<StudentResponse>> GetAllAsync();
    Task<StudentResponse?> GetByIdAsync(int id);
    Task<StudentResponse> AddAsync(CreateStudentRequest request);
    Task<bool> UpdateAsync(UpdateStudentRequest request);
    Task<bool> DeleteAsync(int id);
}
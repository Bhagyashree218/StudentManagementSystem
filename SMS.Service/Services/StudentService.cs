using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Contracts.Response;
using StudentManagementSystem.Repository.Interfaces;
using StudentManagementSystem.Service.Interfaces;

namespace StudentManagementSystem.Service.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<StudentResponse>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<StudentResponse?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<StudentResponse> AddAsync(CreateStudentRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new Exception("Name is required");

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new Exception("Email is required");

        return await _repository.AddAsync(request);
    }

    public async Task<bool> UpdateAsync(UpdateStudentRequest request)
    {
        if (request.Id <= 0)
            throw new Exception("Invalid student id");

        return await _repository.UpdateAsync(request);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        if (id <= 0)
            throw new Exception("Invalid student id");

        return await _repository.DeleteAsync(id);
    }
}
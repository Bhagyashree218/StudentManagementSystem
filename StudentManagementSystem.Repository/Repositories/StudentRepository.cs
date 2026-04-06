using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Contracts.Response;
using StudentManagementSystem.Domain.Entities;
using StudentManagementSystem.Repository.Context;
using StudentManagementSystem.Repository.Interfaces;

namespace StudentManagementSystem.Repository.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentResponse>> GetAllAsync()
    {
        return await _context.Students
            .Where(s => s.IsActive) 
            .Select(s => new StudentResponse
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Age = s.Age,
                Course = s.Course
            })
            .ToListAsync();
    }

    public async Task<StudentResponse?> GetByIdAsync(int id)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive); 

        if (student == null) return null;

        return new StudentResponse
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Age = student.Age,
            Course = student.Course
        };
    }

    public async Task<StudentResponse> AddAsync(CreateStudentRequest request)
    {
        var student = new Student
        {
            Name = request.Name,
            Email = request.Email,
            Age = request.Age,
            Course = request.Course,
            IsActive = true 
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return new StudentResponse
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
            Age = student.Age,
            Course = student.Course
        };
    }

    public async Task<bool> UpdateAsync(UpdateStudentRequest request)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == request.Id && s.IsActive);

        if (student == null) return false;

        student.Name = request.Name;
        student.Email = request.Email;
        student.Age = request.Age;
        student.Course = request.Course;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.Id == id && s.IsActive); 

        if (student == null) return false;

        student.IsActive = false; 

        await _context.SaveChangesAsync();
        return true;
    }
}
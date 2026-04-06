using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Contracts.Request;
using StudentManagementSystem.Service.Interfaces;

namespace StudentManagementSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    // GET: api/student
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _service.GetAllAsync();
        return Ok(students);
    }

    // GET: api/student/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var student = await _service.GetByIdAsync(id);

        if (student == null)
            return NotFound("Student not found");

        return Ok(student);
    }

    // POST: api/student
    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentRequest request)
    {
        var result = await _service.AddAsync(request);
        return Ok(result);
    }

    // PUT: api/student
    [HttpPut]
    public async Task<IActionResult> Update(UpdateStudentRequest request)
    {
        var updated = await _service.UpdateAsync(request);

        if (!updated)
            return NotFound("Student not found");

        return Ok("Student updated successfully");
    }

    // DELETE: api/student/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound("Student not found");

        return Ok("Student deleted successfully");
    }
}
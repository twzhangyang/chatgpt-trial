using Microsoft.AspNetCore.Mvc;
using School.Api.Models;
using School.Api.Repository;

namespace School.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly StudentRepository _repository;

    public StudentController(StudentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<List<Student>> GetAllStudents()
    {
        var students = await _repository.GetStudents();
        return students;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Student>> GetStudentById(int id)
    {
        var student = await _repository.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    [HttpPost]
    public async Task<Student> AddStudent(StudentRequest student)
    {
        await _repository.InsertStudent(student.ToStudent());
        return student.ToStudent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStudent(int id, Student student)
    {
        if (id != student.Id)
        {
            return BadRequest();
        }

        await _repository.InsertStudent(student);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var student = await _repository.GetStudentById(id);
        if (student == null)
        {
            return NotFound();
        }

        await _repository.DeleteStudent(id);
        return NoContent();
    }
}

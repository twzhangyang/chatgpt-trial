using Microsoft.EntityFrameworkCore;
using School.Api.Models;
using School.Api.Repository;
using School.Api.Services;

namespace School.Api.Tests;

public class StudentServiceTests
{
    private StudentService _studentService;
    private StudentRepository _studentRepository;
    private SchoolContext _context;

    public StudentServiceTests()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new SchoolContext(options);
        _studentRepository = new StudentRepository(_context);
        _studentService = new StudentService(_studentRepository);
    }

    [Fact]
    public async Task InsertStudent_Success()
    {
        var student = new Student { FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", Age = 20, Enrollments = new List<Enrollment>() };
        await _studentService.InsertStudent(student);
        var insertedStudent = await _studentRepository.GetStudentById(student.Id);
        Assert.Equal(student.FirstName, insertedStudent.FirstName);
        Assert.Equal(student.LastName, insertedStudent.LastName);
        Assert.Equal(student.Email, insertedStudent.Email);
        Assert.Equal(student.Age, insertedStudent.Age);
    }

    [Fact]
    public async Task InsertStudent_FirstNameIsTest_ShouldAssignLastNameToHello()
    {
        var student = new Student { FirstName = "Test", LastName = "Doe", Email = "john.doe@email.com", Age = 20, Enrollments = new List<Enrollment>() };
        await _studentService.InsertStudent(student);
        var insertedStudent = await _studentRepository.GetStudentById(student.Id);
        Assert.Equal("Hello", insertedStudent.LastName);
    }

    [Fact]
    public async Task InsertStudent_InvalidEmail_ShouldThrowException()
    {
        var student = new Student { FirstName = "John", LastName = "Doe", Email = "invalid.email", Age = 20, Enrollments = new List<Enrollment>() };
        var exception = await Assert.ThrowsAsync<Exception>(() => _studentService.InsertStudent(student));
        Assert.Equal("Invalid email format", exception.Message);
    }

    [Fact]
    public async Task InsertStudent_AgeLessThanOrEqualToZero_ShouldThrowException()
    {
        var student = new Student { FirstName = "John", LastName = "Doe", Email = "john.doe@email.com", Age = 0, Enrollments = new List<Enrollment>() };
        var exception = await Assert.ThrowsAsync<Exception>(() => _studentService.InsertStudent(student));
        Assert.Equal("Age should be greater than 0", exception.Message);
    }
}

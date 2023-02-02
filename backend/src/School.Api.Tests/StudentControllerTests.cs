using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.Controllers;
using School.Api.Models;
using School.Api.Repository;

namespace School.Api.Tests;

public class StudentControllerTests
{
    private readonly StudentController _controller;
    private readonly StudentRepository _repository;
    private readonly DbContextOptions<SchoolContext> _options;

    public StudentControllerTests()
    {
        // Arrange
        _options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        var context = new SchoolContext(_options);
        _repository = new StudentRepository(context);
        _controller = new StudentController(_repository);
    }

    [Fact]
    public async void GetAllStudents_ShouldReturnAllStudents()
    {
        // Arrange
        var student1 = new Student
        {
            Id = 1, LastName = "Doe", FirstName = "John", EnrollmentDate = DateTime.Now, Email = "johndoe@email.com",
            Age = 25, Enrollments = new List<Enrollment>()
        };
        var student2 = new Student
        {
            Id = 2, LastName = "Smith", FirstName = "Jane", EnrollmentDate = DateTime.Now,
            Email = "janesmith@email.com", Age = 25, Enrollments = new List<Enrollment>()
        };
        await _repository.InsertStudent(student1);
        await _repository.InsertStudent(student2);

        // Act
        var result = await _controller.GetAllStudents();

        // Assert
        result.Count.Should().Be(2);
        result.Should().Contain(s => s.Id == 1);
        result.Should().Contain(s => s.Id == 2);
    }

    [Fact]
    public async void GetStudentById_ShouldReturnSingleStudent()
    {
        // Arrange
        var student = new Student
        {
            Id = 1, LastName = "Doe", FirstName = "John", EnrollmentDate = DateTime.Now, Email = "johndoe@email.com",
            Age = 25, Enrollments = new List<Enrollment>()
        };
        await _repository.InsertStudent(student);

        // Act
        var result = await _controller.GetStudentById(1);

        // Assert
        var returnedStudent = (result.Result as OkObjectResult).Value as Student;
        returnedStudent.Id.Should().Be(1);
        returnedStudent.LastName.Should().Be("Doe");
        returnedStudent.FirstName.Should().Be("John");
        returnedStudent.EnrollmentDate.Should().Be(student.EnrollmentDate);
        returnedStudent.Email.Should().Be("johndoe@email.com");
        returnedStudent.Age.Should().Be(25);
        returnedStudent.Enrollments.Should().BeEmpty();
    }

    [Fact]
    public async void GetStudentById_ShouldReturnNotFound()
    {
        // Act
        var result = await _controller.GetStudentById(1);

        // Assert
        result.Value.Should().BeNull();
    }

    [Fact]
    public async void AddStudent_ShouldAddStudentToDatabase()
    {
        // Arrange
        var studentRequest = new StudentRequest
        {
            FirstName = "John",
            LastName = "Doe",
            Age = 25,
            Email = "johndoe@email.com",
            EnrollmentDate = DateTime.Now,
            Enrollments = new List<StudentRequest.EnrollmentRequest>
            {
                new() { CourseId = 1, EnrollmentDate  = DateTime.Now}
            }
        };
        // Act
        var result = await _controller.AddStudent(studentRequest);

        // Assert
        var returnedStudent = result;
        returnedStudent.Id.Should().Be(0);
        returnedStudent.LastName.Should().Be("Doe");
        returnedStudent.FirstName.Should().Be("John");
        returnedStudent.EnrollmentDate.Should().Be(studentRequest.EnrollmentDate);
        returnedStudent.Email.Should().Be("johndoe@email.com");
        returnedStudent.Age.Should().Be(25);
        returnedStudent.Enrollments.Count.Should().Be(1);
    }
}

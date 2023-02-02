using Microsoft.EntityFrameworkCore;
using School.Api.Models;
using School.Api.Repository;

namespace School.Api.Tests;

public class StudentRepositoryTests
{
    private readonly StudentRepository _studentRepository;
    private readonly DbContextOptions<SchoolContext> _options;
    private readonly SchoolContext _context;

    public StudentRepositoryTests()
    {
        // Arrange
        _options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        _context = new SchoolContext(_options);
        _studentRepository = new StudentRepository(_context);
    }

    [Fact]
    public async void GetStudentEnrollments_ShouldReturnEnrollmentsForAStudent()
    {
        // Arrange
        var student = new Student
        {
            Id = 1,
            LastName = "LastName1",
            FirstName = "FirstName1",
            Email = "email1@test.com",
            Age = 20,
            EnrollmentDate = new DateTime(2021, 1, 1),
        };
        var enrollment1 = new Enrollment { EnrollmentID = 1, CourseID = 1, StudentID = 1 };
        var enrollment2 = new Enrollment { EnrollmentID = 2, CourseID = 2, StudentID = 1 };
        student.Enrollments.Add(enrollment1);
        student.Enrollments.Add(enrollment2);
        await _studentRepository.InsertStudent(student);

        // Act
        var result = await _studentRepository.GetStudentEnrollmentsAsync(1);

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, e => e.EnrollmentID == 1);
        Assert.Contains(result, e => e.EnrollmentID == 2);
    }

    [Fact]
    public async Task GetStudents_ReturnsListOfStudents()
    {
        // Arrange
        _context.Students.Add(new Student
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            EnrollmentDate = DateTime.Now,
            Email = "john.doe@email.com",
            Age = 21,
            Enrollments = new List<Enrollment>()
        });
        _context.Students.Add(new Student
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Doe",
            EnrollmentDate = DateTime.Now,
            Email = "jane.doe@email.com",
            Age = 22,
            Enrollments = new List<Enrollment>()
        });
        _context.SaveChanges();

        // Act
        var students = await _studentRepository.GetStudents();

        // Assert
        Assert.Equal(2, students.Count);
        Assert.Equal("John", students[0].FirstName);
        Assert.Equal("Jane", students[1].FirstName);
    }

    [Fact]
    public async Task GetStudentById_ReturnsCorrectStudent()
    {
        // Arrange
        _context.Students.Add(new Student
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            EnrollmentDate = DateTime.Now,
            Email = "john.doe@email.com",
            Age = 21,
            Enrollments = new List<Enrollment>()
        });

        // Act
        var student = await _studentRepository.GetStudentById(1);

        // Assert
        Assert.Equal(1, student.Id);
        Assert.Equal("John", student.FirstName);
        Assert.Equal("Doe", student.LastName);
        Assert.Equal("john.doe@email.com", student.Email);
        Assert.Equal(21, student.Age);
    }
}

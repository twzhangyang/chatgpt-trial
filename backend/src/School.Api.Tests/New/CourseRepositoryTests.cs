using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using School.Api.Models;
using School.Api.Models.NewStudent;
using School.Api.NewRepository;

namespace School.Api.Tests.New;

[CollectionDefinition("NoParallel", DisableParallelization = true)]
[Collection("NoParallel")]
public class CourseRepositoryTests
{
    private readonly NewSchoolContext _context;
    private readonly ICourseRepository _repository;

    public CourseRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<NewSchoolContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        _context = new NewSchoolContext(options);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();

        _repository = new CourseRepository(_context);
    }

    [Fact]
    public async Task GetCourses_ShouldReturnAllCourses()
    {
        // Arrange
        var courses = new Course[]
        {
            new Course { CourseId = 1, Title = "Test course 1", Credits = "3" },
            new Course { CourseId = 2, Title = "Test course 2", Credits = "4" },
            new Course { CourseId = 3, Title = "Test course 3", Credits = "5" },
        };
        _context.Courses.AddRange(courses);
        _context.SaveChanges();

        // Act
        var result = await _repository.GetCourses();

        // Assert
        Assert.Equal(3, result.Count());
        Assert.Contains(result, c => c.Title == "Test course 1");
        Assert.Contains(result, c => c.Title == "Test course 2");
        Assert.Contains(result, c => c.Title == "Test course 3");    }

    [Fact]
    public async Task GetCourseById_ShouldReturnCorrectCourse()
    {
        // Arrange
        var courses = new Course[]
        {
            new Course { CourseId = 1, Title = "Test course 1", Credits = "3" },
            new Course { CourseId = 2, Title = "Test course 2", Credits = "4" },
            new Course { CourseId = 3, Title = "Test course 3", Credits = "5" },
        };
        _context.Courses.AddRange(courses);
        _context.SaveChanges();

        // Act
        var result = await _repository.GetCourseById(2);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test course 2", result.Title);
        // Act
        var result2 = await _repository.GetCourseById(1);

        // Assert
        result2.Should().BeEquivalentTo(courses[0]);
    }

    [Fact]
    public async Task AddCourse_ShouldAddCourseToDb()
    {
        // Arrange
        var course = new Course { CourseId = 1, Credits = "4", Title = "English" };

        // Act
        _repository.AddCourse(course);
        var result = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == 1);

        // Assert
        result.Should().BeEquivalentTo(course);
    }

    [Fact]
    public async Task UpdateCourse_ShouldUpdateCourseInDb()
    {
        // Arrange
        var courses = new List<Course>
        {
            new Course { CourseId = 1, Credits = "4", Title = "English" },
            new Course { CourseId = 2, Credits = "3", Title = "Mathematics" }
        };
        _context.Courses.AddRange(courses);
        _context.SaveChanges();

        var result = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == 1);
        result!.Title = "update";

        // Act
        _repository.UpdateCourse(result);
        var result2 = await _context.Courses.FirstOrDefaultAsync(c => c.CourseId == 1);

        // Assert
        result2!.Title.Should().Be("update");
    }

    [Fact]
    public void DeleteCourse_ShouldDeleteCourseFromDb()
    {
        // Arrange
        var course = new Course { CourseId = 1, Credits = "2", Title = "Test course" };
        _context.Courses.Add(course);
        _context.SaveChanges();

        // Act
        _repository.DeleteCourse(course);
        _context.SaveChanges();

        // Assert
        var deletedCourse = _context.Courses.SingleOrDefault(c => c.CourseId == course.CourseId);
        Assert.Null(deletedCourse);
    }
}


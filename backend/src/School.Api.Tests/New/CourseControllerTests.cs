using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using School.Api.Controllers;
using School.Api.Models;
using School.Api.Models.NewStudent;
using School.Api.NewRepository;

namespace School.Api.Tests.New
{
    public class CourseControllerTests
    {
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly CourseController _courseController;

        public CourseControllerTests()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _courseController =
                new CourseController(_courseRepositoryMock.Object);
        }

        [Fact]
        public async Task GetCourses_ShouldReturnAllCourses()
        {
            // Arrange
            var courses = new List<Course>
            {
                new Course { CourseId = 1, Title = "Test Course 1", Credits = "3", },
                new Course { CourseId = 2, Title = "Test Course 2", Credits = "4", },
                new Course { CourseId = 3, Title = "Test Course 3", Credits = "5", },
            };

            _courseRepositoryMock.Setup(x => x.GetCourses()).ReturnsAsync(courses);

            // Act
            var result = await _courseController.GetCourses();

            // Assert
            var okResult = Assert.IsType<ActionResult<IEnumerable<CourseResponse>>>(result);
            var responseCourses = (okResult.Result as OkObjectResult)?.Value as IEnumerable<CourseResponse>;
            Assert.Equal(courses.Count(), responseCourses!.Count());
        }

        [Fact]
        public async Task GetCourse_ShouldReturnCourse_WhenExistingCourseIdIsProvided()
        {
            // Arrange
            var courseId = 1;
            var course = new Course { CourseId = courseId, Title = "Test Course", Credits = "3", };

            _courseRepositoryMock.Setup(x => x.GetCourseById(courseId)).ReturnsAsync(course);

            // Act
            var result = await _courseController.GetCourse(courseId.ToString());

            // Assert
            var responseCourse = (result.Result as OkObjectResult)?.Value as CourseResponse;
            Assert.Equal(course.CourseId, responseCourse.CourseId);
            Assert.Equal(course.Title, responseCourse.Title);
            Assert.Equal(course.Credits, responseCourse.Credits);
        }

        [Fact]
        public async Task GetCourse_ShouldReturnNotFound_WhenNonExistingCourseIdIsProvided()
        {
            // Arrange
            var courseId = 1;
            Course course = null;

            _courseRepositoryMock.Setup(x => x.GetCourseById(courseId))!.ReturnsAsync(course);

            // Act
            var result = await _courseController.GetCourse(courseId.ToString());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}

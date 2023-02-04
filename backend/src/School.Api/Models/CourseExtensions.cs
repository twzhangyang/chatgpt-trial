using School.Api.Models.NewStudent;

namespace School.Api.Models;

public class CourseRequest
{
    public string CourseId { get; set; }
    public string Title { get; set; }
    public string Credits { get; set; }
}

public class CourseResponse
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Credits { get; set; }
}

public static class CourseExtensions
{
    public static Course? ToCourse(this CourseRequest courseRequest)
    {
        return new Course
        {
            CourseId = int.Parse(courseRequest.CourseId),
            Title = courseRequest.Title,
            Credits = courseRequest.Credits
        };
    }

    public static CourseResponse ToCourseResponse(this Course? course)
    {
        return new CourseResponse
        {
            CourseId = course.CourseId,
            Title = course.Title,
            Credits = course.Credits,
        };
    }
}

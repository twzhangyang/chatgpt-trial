namespace School.Api.Models;

public static class StudentRequestExtension
{
    public static Student ToStudent(this StudentRequest request)
    {
        return new Student
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Age = request.Age,
            EnrollmentDate = request.EnrollmentDate,
            Enrollments = request.Enrollments.Select(e => new Enrollment()
            {
                CourseID = e.CourseId
            }).ToList()
        };
    }
}

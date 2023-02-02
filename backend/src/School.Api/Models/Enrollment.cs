namespace School.Api.Models;

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }

    public Student Student { get; set; }
}

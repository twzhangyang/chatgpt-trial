namespace School.Api.Models;

public class StudentRequest
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public ICollection<EnrollmentRequest> Enrollments { get; set; }

    public class EnrollmentRequest
    {
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}

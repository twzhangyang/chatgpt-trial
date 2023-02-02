namespace School.Api.Models;

public class Student
{
    public Student()
    {
        Enrollments = new List<Enrollment>();
    }
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}


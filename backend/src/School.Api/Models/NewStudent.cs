using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Models.NewStudent;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}

public class Enrollment
{
    public int EnrollmentID { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }

    public Student Student { get; set; }
    public Course Course { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public string Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}

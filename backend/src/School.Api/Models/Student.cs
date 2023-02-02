using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Models;

public class Student
{
    public Student()
    {
        Enrollments = new List<Enrollment>();
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
}


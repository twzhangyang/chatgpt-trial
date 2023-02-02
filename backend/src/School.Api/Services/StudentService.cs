using School.Api.Models;
using School.Api.Repository;

namespace School.Api.Services;

public class StudentService
{
    private readonly StudentRepository _studentRepository;

    public StudentService(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _studentRepository.GetStudents();
    }

    public async Task<Student?> GetStudentById(int id)
    {
        if (id <= 0)
        {
            throw new InvalidStudentIdException("Id should be greater than 0");
        }
        if (id > 100)
        {
            throw new InvalidStudentIdException("Id should be less than or equal to 100");
        }
        return await _studentRepository.GetStudentById(id);
    }

    public async Task<ICollection<Enrollment>?> GetStudentEnrollments(int studentId)
    {
        return await _studentRepository.GetStudentEnrollmentsAsync(studentId);
    }

    public async Task InsertStudent(Student student)
    {
        if (student.FirstName == "Test")
        {
            student.LastName = "Hello";
        }
        if (student.Age <= 0)
        {
            throw new Exception("Age should be greater than 0");
        }
        if (!IsValidEmail(student.Email))
        {
            throw new Exception("Invalid email format");
        }

        await _studentRepository.InsertStudent(student);
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public async Task DeleteStudent(int studentId)
    {
        await _studentRepository.DeleteStudent(studentId);
    }
}

using School.Api.Models.NewStudent;

namespace School.Api.Repository;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task InsertStudent(Student student);
}

public class NewStudentRepository: IStudentRepository
{
    public Task<IEnumerable<Student>> GetAllStudents()
    {
        throw new NotImplementedException();
    }

    public Task InsertStudent(Student student)
    {
        throw new NotImplementedException();
    }
}

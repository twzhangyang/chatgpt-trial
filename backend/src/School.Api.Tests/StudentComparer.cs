using School.Api.Models;

namespace School.Api.Tests;

public class StudentComparer : IEqualityComparer<Student>
{
    public bool Equals(Student x, Student y)
    {
        return x.Id == y.Id && x.LastName == y.LastName && x.FirstName == y.FirstName;
    }

    public int GetHashCode(Student obj)
    {
        return obj.Id.GetHashCode();
    }
}

using Microsoft.EntityFrameworkCore;
using School.Api.Models.NewStudent;

namespace School.Api.NewRepository;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetCourses();
    Task<Course> GetCourseById(int id);
    void AddCourse(Course course);
    void UpdateCourse(Course course);
    void DeleteCourse(Course course);
    Task<bool> SaveChanges();
}

public class CourseRepository : ICourseRepository
{
    private readonly NewSchoolContext _context;

    public CourseRepository(NewSchoolContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Course>> GetCourses()
    {
        return await _context.Courses.ToListAsync();
    }

    public async Task<Course> GetCourseById(int id)
    {
        return await _context.Courses.FindAsync(id);
    }

    public void AddCourse(Course course)
    {
        _context.Courses.Add(course);
    }

    public void UpdateCourse(Course course)
    {
        _context.Courses.Update(course);
    }

    public void DeleteCourse(Course course)
    {
        _context.Courses.Remove(course);
    }

    public async Task<bool> SaveChanges()
    {
        return (await _context.SaveChangesAsync() > 0);
    }
}

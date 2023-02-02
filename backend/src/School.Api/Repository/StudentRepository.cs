using Microsoft.EntityFrameworkCore;
using School.Api.Models;

namespace School.Api.Repository;

using System.Collections.Generic;
using System.Linq;

public class StudentRepository
{
    private SchoolContext context;

    public StudentRepository(SchoolContext context)
    {
        this.context = context;
    }

   public async Task<List<Student>> GetStudents()
    {
        return await context.Students.ToListAsync();
    }

    public async Task<Student?> GetStudentById(int id)
    {
        return await context.Students.FindAsync(id);
    }

    public async Task<ICollection<Enrollment>?> GetStudentEnrollmentsAsync(int studentId)
    {
        var student = await context.Students.Include(s => s.Enrollments).FirstOrDefaultAsync(s => s.Id == studentId);
        return student?.Enrollments;
    }


    public async Task InsertStudent(Student student)
    {
        context.Students.Add(student);
        await context.SaveChangesAsync();
    }

    public async Task DeleteStudent(int studentId)
    {
        var student = await context.Students.FindAsync(studentId);
        context.Students.Remove(student);
        await context.SaveChangesAsync();
    }
}

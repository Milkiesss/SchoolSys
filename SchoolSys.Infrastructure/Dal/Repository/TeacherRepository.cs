using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
{
    private readonly DataContext _context;
    public TeacherRepository(DataContext context) : base(context)
    {
        _context = context;
    }
    

    public async Task<bool> AddTeacherSubjectAsync(Guid teacherId, Guid subjectId)
    {
        var teacher = await _context.Teachers.FindAsync(teacherId);
        var subject = await _context.Subjects.FindAsync(subjectId);

        if (teacher == null || subject == null)
            return false;

        if (await _context.TeacherSubjectsvies.AnyAsync(ts => ts.TeacherId == teacherId && ts.SubjectId == subjectId))
            return false;

        var teacherSubject = new TeacherSubject
        {
            TeacherId = teacherId,
            SubjectId = subjectId
        };

        await _context.TeacherSubjectsvies.AddAsync(teacherSubject);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTeacherSubjectAsync(Guid teacherId, Guid subjectId)
    {
        var teacherSubject = await _context.TeacherSubjectsvies.
            FirstOrDefaultAsync(ts => ts.TeacherId == teacherId && ts.SubjectId == subjectId);
        
        if (teacherSubject is null)
            return false;
        
        _context.TeacherSubjectsvies.Remove(teacherSubject);
        await _context.SaveChangesAsync();
        return true;
    }
}
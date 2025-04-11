using System.Collections;
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class SessionRepository :  BaseRepository<Session>,ISessionRepository
{
    private readonly DataContext _context;
    public SessionRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Session>> GetSessionsByGroupIdAsync(string groupName, DateTime Year)
    {
        var session = await _context.Sessions.AsNoTracking()
            .Where(s => s.Group.Name == groupName && s.SessionDate.Year == Year.Year)
            .Include(s => s.Group)
            .Include(s => s.Subjects)
                .ThenInclude(ss => ss.Subject)
            .Include(s => s.Subjects)
                .ThenInclude(ss => ss.Students)
                    .ThenInclude(ss => ss.Student)
            .AsSplitQuery()
            .ToListAsync();
        return session;
    }
    public async Task<Session> GetByIdWithSubjectAsync(Guid id)
    {
        return await _context.Sessions.AsTracking()
            .Include(s=>s.Subjects)
            .FirstOrDefaultAsync(x=>x.Id==id);
    }
    public async Task<bool> CreateSessionSubjectAsync(ICollection<SessionSubject> subjects)
    {
        await _context.SessionSubjects.AddRangeAsync(subjects);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CreateSessionStudentAsync(ICollection<SessionStudent> sessionStudents)
    {
        await _context.SessionStudents.AddRangeAsync(sessionStudents);
        await _context.SaveChangesAsync();
        return true;
    }
}
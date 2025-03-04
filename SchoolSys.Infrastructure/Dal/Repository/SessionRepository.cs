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

    public async Task<ICollection<Session>> GetSessionsByGroupIdAsync(Guid groupId)
    {
        return await _context.Sessions
            .Include(x=>x.Subject)
            .Include(x=>x.Group)
            .Where(x=>x.GroupId == groupId)
            .ToListAsync();
    }
    
    public async Task<ICollection<Session>> GetSessionsByDateRangeAsync(DateTime Date)
    {
        return await _context.Sessions
            .Include(s => s.Group)
            .Include(s => s.Subject)
            .Where(s => s.SessionDate == Date)
            .ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    private DataContext _context;
    public LessonRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Lesson>> GetLessonsByGroupIdAsync(Guid groupId)
    {
        return await _context.Lessons
            .Where(l => l.GroupId == groupId)
            .ToListAsync();
    }

    public async Task<ICollection<Lesson>> GetLessonsByTeacherIdAsync(Guid teacherId)
    {
        return await _context.Lessons
            .Where(l => l.TeacherId == teacherId)
            .ToListAsync();
    }
}
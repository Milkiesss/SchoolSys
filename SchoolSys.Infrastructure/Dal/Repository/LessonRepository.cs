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
            .Where(l => l.GroupId == groupId && l.LessonDate >= DateTime.Today && l.LessonDate <= DateTime.Today.AddDays(7))
            .ToListAsync();
    }
    public async Task<ICollection<Lesson>> GetTeacherLessonsCountInDaysAsync(Guid teacherId, int days)
    {
        var StartDate = DateTime.Now.Date;
        var EndDate = StartDate.AddDays(days);
        return await _context.Lessons.Where(x=>x.LessonDate >= StartDate && x.LessonDate <=EndDate && x.TeacherId == teacherId).ToListAsync();
    }
}
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class StudentRepository : BaseRepository<Student> ,IStudentRepository
{
    private DataContext _context;
    public StudentRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Student>> GetStudentsByGroupIdAsync(Guid groupId)
    {
        return await _context.Students
            .Where(s => s.GroupId == groupId)
            .ToListAsync();
    }

    public async Task<List<Student>> GetStudentHistoryByIdAsync(Guid studentId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
            throw new ArgumentException("Студент не найден", nameof(studentId));

        return await _context.Students.Include(h => h.History)
            .Where(h => h.Id == studentId).ToListAsync();
    }
}
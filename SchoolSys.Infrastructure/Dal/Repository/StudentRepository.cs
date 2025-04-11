using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Domain.enums;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class StudentRepository : BaseRepository<Student> ,IStudentRepository
{
    private DataContext _context;
    public StudentRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Student>> GetStudentsByGroupNameAsync(string groupName)
    {
        return await _context.Students
            .Where(s => s.Group.Name == groupName)
            .ToListAsync();
    }

    public async Task<Student> GetStudentHistoryByIdAsync(Guid studentId)
    {
        var student = await _context.Students.FindAsync(studentId);
        if (student == null)
            throw new ArgumentException("Студент не найден", nameof(studentId));

        return await _context.Students.Include(h => h.History)
            .FirstOrDefaultAsync(h => h.Id == studentId);
    }

    public async Task<ICollection<Student>> GetStudentsByFacultyAndByYearAsync(int year, Guid facultyId)
    {
        return await _context.Students
            .Include(x => x.History)
            .Include(x => x.Group)
            .Where(x => x.Status == StudentStatus.Enrolled && x.Group.FacultyId == facultyId).ToListAsync();
    }
}
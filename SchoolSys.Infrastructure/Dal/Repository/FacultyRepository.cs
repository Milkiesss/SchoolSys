
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class FacultyRepository: BaseRepository<Faculty>, IFacultyRepository 
{
    private readonly DataContext _context;
    public FacultyRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Teacher>> GetTeachersByFacultyIdAsync(Guid facultyId)
    {
        return await _context.Teachers
            .Include(t => t.TeacherSubjects)
            .ThenInclude(ts => ts.Subject)
            .Where(t => t.TeacherSubjects.Any(ts => ts.Subject.FacultyId == facultyId))
            .ToListAsync();
    }
}
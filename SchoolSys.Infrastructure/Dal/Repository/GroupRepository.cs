using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    private readonly DataContext _context;
    public GroupRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ICollection<Group>> GetGroupsByFacultyIdAsync(Guid facultyId)
    {
        return await _context.Groups
            .Where(g => g.FacultyId == facultyId)
            .ToListAsync();
    }
}
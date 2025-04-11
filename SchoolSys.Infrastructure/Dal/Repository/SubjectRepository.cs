using System.Collections;
using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
{
    private readonly DataContext _context;
    public SubjectRepository(DataContext context) : base(context)
    {
        _context = context;
    }
    public async Task<ICollection<Guid>> GetSubjectsByNamesAsync(ICollection<string> subjectNames)
    {
        return await _context.Subjects
            .Where(x => subjectNames.Contains(x.Name))
            .Select(x=>x.Id).ToListAsync();
    }

    public async Task<ICollection<Subject>> GetSubjectsByIdsAsync(ICollection<Guid> subjectIds)//todo нужен не?
    {
        return await _context.Subjects.Where(x => subjectIds.Contains(x.Id)).ToListAsync();
    }
}
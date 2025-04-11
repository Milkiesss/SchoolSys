using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ISubjectRepository : IBaseRepository<Subject>
{
    Task<ICollection<Subject>> GetSubjectsByIdsAsync(ICollection<Guid> subjectIds);
    Task<ICollection<Guid>> GetSubjectsByNamesAsync(ICollection<string> subjectNames);
}
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IGroupRepository : IBaseRepository<Group>
{
    public Task<ICollection<Group>> GetGroupsByFacultyIdAsync(Guid facultyId);
}
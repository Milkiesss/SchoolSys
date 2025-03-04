using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task<ICollection<Session>> GetSessionsByGroupIdAsync(Guid groupId);
    Task<ICollection<Session>> GetSessionsByDateRangeAsync(DateTime Date);
}
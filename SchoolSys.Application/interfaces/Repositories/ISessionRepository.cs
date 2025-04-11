using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ISessionRepository : IBaseRepository<Session>
{
    Task<ICollection<Session>> GetSessionsByGroupIdAsync(string groupName, DateTime Year);
    Task<bool> CreateSessionSubjectAsync(ICollection<SessionSubject> subjects);
    Task<bool> CreateSessionStudentAsync(ICollection<SessionStudent> sessionStudents);
    Task<Session> GetByIdWithSubjectAsync(Guid id);
}
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.Dtos.SessionDto.Responce;

namespace SchoolSys.Application.interfaces.Services;

public interface ISessionService
{
    Task<Guid> AddAsync(CreateSessionRequest createSessionRequest);
    Task<bool> UpdateAsync(UpdateSessionRequest updateSessionRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<GetSessionResponce> GetByIdAsync(Guid id);
    Task<ICollection<GetSessionResponce>> GetSessionsByGroupIdAsync(Guid groupId);
    Task<ICollection<GetSessionResponce>> GetSessionsByDateRangeAsync(DateTime Date);
}
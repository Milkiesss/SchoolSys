using System.Security.Claims;
using AutoMapper;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.Dtos.SessionDto.Responce;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IMapper _mapper;

    public SessionService(ISessionRepository sessionRepository, IMapper mapper)
    {
        _sessionRepository = sessionRepository;
        _mapper = mapper;
    }


    public async Task<Guid> AddAsync(CreateSessionRequest createSessionRequest)
    {
        var session = _mapper.Map<Session>(createSessionRequest);
        await _sessionRepository.AddAsync(session);
        return session.Id;
    }

    public async Task<bool> UpdateAsync(UpdateSessionRequest updateSessionRequest)
    {
        var session = await _sessionRepository.GetByIdAsync(updateSessionRequest.Id);
        if (session == null)
            return false;

        _mapper.Map(updateSessionRequest, session);
        return await _sessionRepository.UpdateAsync(session);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var session = await _sessionRepository.GetByIdAsync(id);
        if (session == null)
            return false;

        return await _sessionRepository.DeleteAsync(session);
    }

    public async Task<GetSessionResponce> GetByIdAsync(Guid id)
    {
        var session = await _sessionRepository.GetByIdAsync(id);
        if (session == null)
            return null;

        return _mapper.Map<GetSessionResponce>(session);
    }

    public async Task<ICollection<GetSessionResponce>> GetSessionsByGroupIdAsync(Guid groupId)
    {
        var sessions = await _sessionRepository.GetAllAsync();
        return _mapper.Map<ICollection<GetSessionResponce>>(sessions);
    }

    public async Task<ICollection<GetSessionResponce>> GetSessionsByDateRangeAsync(DateTime Date)
    {
        var sessions = await _sessionRepository.GetSessionsByDateRangeAsync(Date);
        return _mapper.Map<ICollection<GetSessionResponce>>(sessions);
    }
}
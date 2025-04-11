using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.Dtos.SessionDto.Responce;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class SessionService : ISessionService
{
    private readonly ISessionRepository _sessionRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;

    public SessionService(ISessionRepository sessionRepository, IMapper mapper, ISubjectRepository subjectRepository, IStudentRepository studentRepository)
    {
        _sessionRepository = sessionRepository;
        _mapper = mapper;
        _subjectRepository = subjectRepository;
        _studentRepository = studentRepository;
    }


    public async Task<Guid> AddAsync(CreateSessionRequest createSessionRequest)
    {
        // Получаем студентов группы
        var students = await _studentRepository.GetStudentsByGroupNameAsync(createSessionRequest.groupNumber);
        createSessionRequest.GroupId = students.FirstOrDefault()?.GroupId ?? Guid.Empty;

        // Получаем предметы по названиям
        var subjectsFromDb = await _subjectRepository.GetSubjectsByNamesAsync(createSessionRequest.Subjects);

        // Создаем сессию
        var session = _mapper.Map<Session>(createSessionRequest);
        await _sessionRepository.AddAsync(session);

        // Создаем объекты предметов сессии
        var sessionSubjects = subjectsFromDb
            .Select(subject => new SessionSubject(Guid.NewGuid(), session.Id, subject))
            .ToList();
        await _sessionRepository.CreateSessionSubjectAsync(sessionSubjects);

        // Создаем связи студентов с предметами
        var sessionStudents = sessionSubjects
            .SelectMany(ss => students.Select(student => new SessionStudent(ss.Id, student.Id)))
            .ToList();
        await _sessionRepository.CreateSessionStudentAsync(sessionStudents);

        return session.Id;
    }

    public async Task<bool> UpdateAsync(UpdateSessionRequest updateSessionRequest)//todo if add
    {
        var session = await _sessionRepository.GetByIdWithSubjectAsync(updateSessionRequest.Id);
        if (session == null)
            return false;

        _mapper.Map(updateSessionRequest,session);
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

    public async Task<ICollection<GetSessionResponce>> GetSessionsByGroupIdAsync(string groupName, DateTime Year)
    {
        var sessions = await _sessionRepository.GetSessionsByGroupIdAsync(groupName, Year);
        return _mapper.Map<ICollection<GetSessionResponce>>(sessions);
    }
}
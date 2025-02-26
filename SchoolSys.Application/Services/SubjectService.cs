using AutoMapper;
using SchoolSys.Application.Dtos.SubjectDto.Request;
using SchoolSys.Application.Dtos.SubjectDto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private IMapper _mapper;
    public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CreateSubjectRequest createSubjectRequest)
    {
        var subject = _mapper.Map<Subject>(createSubjectRequest);
        await _subjectRepository.AddAsync(subject);
        return subject.Id;
    }

    public async Task<bool> UpdateAsync(UpdateSubjectRequest updateSubjectRequest)
    {
        var subject = await _subjectRepository.GetByIdAsync(updateSubjectRequest.Id);
        if (subject == null)
            return false;

        _mapper.Map(updateSubjectRequest, subject);
        return await _subjectRepository.UpdateAsync(subject);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var subject = await _subjectRepository.GetByIdAsync(id);
        if (subject == null)
            return false;

        return await _subjectRepository.DeleteAsync(subject);
    }

    public async Task<GetSubjectResponse> GetByIdAsync(Guid id)
    {
        var subject = await _subjectRepository.GetByIdAsync(id);
        return _mapper.Map<GetSubjectResponse>(subject);
    }

    public async Task<ICollection<GetSubjectResponse>> GetAllAsync()
    {
        var subjects = await _subjectRepository.GetAllAsync();
        return _mapper.Map<ICollection<GetSubjectResponse>>(subjects);
    }
}
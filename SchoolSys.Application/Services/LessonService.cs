using AutoMapper;
using SchoolSys.Application.Dtos.LessonDto.Request;
using SchoolSys.Application.Dtos.LessonDto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class LessonService : ILessonService
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IMapper _mapper;

    public LessonService(ILessonRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CreateLessonRequest createLessonRequest)
    {
        var lesson = _mapper.Map<Lesson>(createLessonRequest);
        await _lessonRepository.AddAsync(lesson);
        return lesson.Id;
    }

    public async Task<bool> UpdateAsync(UpdateLessonRequest updateLessonRequest)
    {
        var lesson = await _lessonRepository.GetByIdAsync(updateLessonRequest.Id);
        if (lesson == null)
            return false;

        _mapper.Map(updateLessonRequest, lesson);
        return await _lessonRepository.UpdateAsync(lesson);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var lesson = await _lessonRepository.GetByIdAsync(id);
        if (lesson == null)
            return false;

        return await _lessonRepository.DeleteAsync(lesson);
    }
    

    public async Task<ICollection<GetLessonResponse>> GetLessonsByGroupIdAsync(Guid groupId)
    {
        var lessons = await _lessonRepository.GetLessonsByGroupIdAsync(groupId);
        return _mapper.Map<ICollection<GetLessonResponse>>(lessons);
    }

    public async Task<ICollection<GetLessonResponse>> GetLessonsByTeacherIdAsync(Guid teacherId)
    {
        var lessons = await _lessonRepository.GetLessonsByTeacherIdAsync(teacherId);
        return _mapper.Map<ICollection<GetLessonResponse>>(lessons);
    }
}
using SchoolSys.Application.Dtos.LessonDto.Request;
using SchoolSys.Application.Dtos.LessonDto.Response;

namespace SchoolSys.Application.interfaces.Services;

public interface ILessonService
{
    Task<Guid> AddAsync(CreateLessonRequest createLessonRequest);
    Task<bool> UpdateAsync(UpdateLessonRequest updateLessonRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<ICollection<GetLessonResponse>> GetLessonsByGroupIdAsync(Guid groupId);
    Task<ICollection<GetLessonResponse>> GetLessonsByTeacherIdAsync(Guid teacherId);
}
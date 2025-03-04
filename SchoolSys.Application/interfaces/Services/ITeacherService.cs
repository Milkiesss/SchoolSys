using SchoolSys.Application.Dtos.TeacherDto.Request;
using SchoolSys.Application.Dtos.TeacherDto.Response;

namespace SchoolSys.Application.interfaces.Services;

public interface ITeacherService
{
    Task<Guid> AddAsync(CreateTeacherRequest createTeacherRequest);
    Task<bool> UpdateAsync(UpdateTeacherRequest updateTeacherRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<GetTeacherResponse> GetByIdAsync(Guid id);
    Task<ICollection<GetTeacherResponse>> GetAllAsync();
    Task<ICollection<GetTeacherResponse>> GetTeachersByFacultyIdAsync(Guid facultyId);
    Task<bool> AddTeacherSubjectAsync(Guid teacherId, Guid subjectId);
    Task<bool> DeleteTeacherSubjectAsync(Guid teacherId, Guid subjectId);
}
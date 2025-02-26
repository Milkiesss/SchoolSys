using SchoolSys.Application.Dtos.FacultyDto.Request;
using SchoolSys.Application.Dtos.FacultyDto.Response;
using SchoolSys.Application.Dtos.TeacherDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Services;

public interface IFacultyService
{
    Task<Guid> AddAsync(CreateFacultyRequest createFacultyRequest);
    Task<bool> UpdateAsync(UpdateFacultyRequest updateFacultyRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<GetFacultyResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<GetFacultyResponse>> GetAllAsync();
    Task<ICollection<GetTeacherResponse>> GetTeachersByFacultyIdAsync(Guid facultyId);
}
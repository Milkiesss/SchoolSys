using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Response;

namespace SchoolSys.Application.interfaces.Services;

public interface IStudentService
{
    Task<GetStudentResponse> GetByIdAsync(Guid id);
    Task<GetStudentWithHistoryResponse> GetByIdWithHistoryAsync(Guid id);
    Task<Guid> AddAsync(CreateStudentRequest createStudentRequest);
    Task<bool> UpdateAsync(UpdateStudentRequest updateStudentRequest);
    Task<ICollection<GetStudentResponse>> GetStudentsByYearAndFacultyAsync(int year, Guid facultyId);
    Task<GetStudentResponse> GetStudentByGetStudentHistoryByIdAsyncIdAsync(Guid studentId);
    Task<ICollection<GetStudentResponse>> GetStudentsByGroupIdAsync(string groupName);
    Task<bool> DeleteAsync(Guid id);
}
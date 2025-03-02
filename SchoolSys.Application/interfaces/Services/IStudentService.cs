using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Responce;

namespace SchoolSys.Application.interfaces.Services;

public interface IStudentService
{
    Task<GetStudentResponse> GetByIdAsync(Guid id);
    Task<GetStudentWithHistoryResponse> GetByIdWithHistoryAsync(Guid id);
    Task<IEnumerable<GetStudentResponse>> GetAllAsync();
    Task<Guid> AddAsync(CreateStudentRequest createStudentRequest);
    Task<bool> UpdateAsync(UpdateStudentRequest updateStudentRequest);
    Task<ICollection<GetStudentResponse>> GetStudentsByYearAsync(int year);
    Task<ICollection<GetStudentResponse>> GetStudentByIdAsync(Guid studentId);
    Task<ICollection<GetStudentResponse>> GetStudentsByGroupIdAsync(Guid groupId);
    Task<bool> DeleteAsync(Guid id);
}
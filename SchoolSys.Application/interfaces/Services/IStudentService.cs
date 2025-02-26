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
    Task<bool> DeleteAsync(Guid id);
}
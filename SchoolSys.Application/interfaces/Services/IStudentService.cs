using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Responce;

namespace SchoolSys.Application.interfaces.Services;

public interface IStudentService
{
    public Task<GetStudentResponce> GetByIdAsync(Guid id);
    public Task<GetStudentWithHistoryResponce> GetByIdWithHistoryAsync(Guid id);
    public Task<IEnumerable<GetStudentResponce>> GetAllAsync();
    public Task<Guid> AddAsync(CreateStudentRequest createStudentRequest);
    public Task<bool> UpdateAsync(UpdateStudentRequest updateStudentRequest);
    public Task<bool> DeleteAsync(Guid id);
}
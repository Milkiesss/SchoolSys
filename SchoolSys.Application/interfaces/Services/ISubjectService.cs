using SchoolSys.Application.Dtos.SubjectDto.Request;
using SchoolSys.Application.Dtos.SubjectDto.Response;

namespace SchoolSys.Application.interfaces.Services;

public interface ISubjectService
{
    Task<Guid> AddAsync(CreateSubjectRequest createSubjectRequest);
    Task<bool> UpdateAsync(UpdateSubjectRequest updateSubjectRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<GetSubjectResponse> GetByIdAsync(Guid id);
    Task<ICollection<GetSubjectResponse>> GetAllAsync();
}
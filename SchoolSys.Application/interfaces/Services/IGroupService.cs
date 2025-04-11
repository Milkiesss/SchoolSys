using SchoolSys.Application.Dtos.GroupDto.Request;
using SchoolSys.Application.Dtos.GroupDto.Response;

namespace SchoolSys.Application.interfaces.Services;

public interface IGroupService
{
    Task<Guid> AddAsync(CreateGroupRequest createGroupRequest);
    Task<bool> UpdateAsync(UpdateGroupRequest updateGroupRequest);
    Task<bool> DeleteAsync(Guid id);
    Task<GetGroupResponse> GetByIdAsync(Guid id);
    Task<IEnumerable<GetGroupResponse>> GetAllAsync();
    Task<ICollection<GetGroupResponse>> GetGroupsByFacultyIdAsync(Guid facultyId);
}
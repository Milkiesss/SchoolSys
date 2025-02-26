using AutoMapper;
using SchoolSys.Application.Dtos.Groupto.Request;
using SchoolSys.Application.Dtos.Groupto.Response;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<Guid> AddAsync(CreateGroupRequest createGroupRequest)
    {
        var group = _mapper.Map<Group>(createGroupRequest);
        await _groupRepository.AddAsync(group);
        return group.Id;
    }

    public async Task<bool> UpdateAsync(UpdateGroupRequest updateGroupRequest)
    {
        var group = await _groupRepository.GetByIdAsync(updateGroupRequest.Id);
        if (group == null)
            return false;

        _mapper.Map(updateGroupRequest, group);
        return await _groupRepository.UpdateAsync(group);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var group = await _groupRepository.GetByIdAsync(id);
        if (group == null)
            return false;

        return await _groupRepository.DeleteAsync(group);
    }

    public async Task<GetGroupResponse> GetByIdAsync(Guid id)
    {
        var group = await _groupRepository.GetByIdAsync(id);
        return _mapper.Map<GetGroupResponse>(group);
    }

    public async Task<IEnumerable<GetGroupResponse>> GetAllAsync()
    {
        var groups = await _groupRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<GetGroupResponse>>(groups);
    }

    public async Task<ICollection<GetGroupResponse>> GetGroupsByFacultyIdAsync(Guid facultyId)
    {
        var groups = await _groupRepository.GetGroupsByFacultyIdAsync(facultyId);
        return _mapper.Map<ICollection<GetGroupResponse>>(groups);
    }
}
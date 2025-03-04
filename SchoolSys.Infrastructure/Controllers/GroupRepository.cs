using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.Groupto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly IGroupService _groupService;

    public GroupController(IGroupService groupService)
    {
        _groupService = groupService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create([FromBody] CreateGroupRequest request)
    {
        var groupId = await _groupService.AddAsync(request);
        return Ok(groupId);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update([FromBody] UpdateGroupRequest request)
    {
        var result = await _groupService.UpdateAsync(request);
        return result ? Ok() : NotFound("Group not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _groupService.DeleteAsync(id);
        return result ? Ok() : NotFound("Group not found");
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var group = await _groupService.GetByIdAsync(id);
        if (group == null)
            return NotFound("Group not found");

        return Ok(group);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _groupService.GetAllAsync();
        return Ok(groups);
    }

    [HttpGet("by-faculty/{facultyId:guid}")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetGroupsByFacultyId(Guid facultyId)
    {
        var groups = await _groupService.GetGroupsByFacultyIdAsync(facultyId);
        return Ok(groups);
    }
}
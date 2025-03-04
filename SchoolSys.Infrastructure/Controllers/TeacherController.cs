// SchoolSys.Web/Controllers/TeacherController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.TeacherDto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/teachers")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create([FromBody] CreateTeacherRequest request)
    {
        var teacherId = await _teacherService.AddAsync(request);
        return Ok(teacherId);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTeacherRequest request)
    {
        var result = await _teacherService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _teacherService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var teacher = await _teacherService.GetByIdAsync(id);
        return Ok(teacher);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetAll()
    {
        var teachers = await _teacherService.GetAllAsync();
        return Ok(teachers);
    }

    [HttpGet("by-faculty/{facultyId:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetTeachersByFacultyId(Guid facultyId)
    {
        var teachers = await _teacherService.GetTeachersByFacultyIdAsync(facultyId);
        return Ok(teachers);
    }

    [HttpPost("{teacherId:guid}/subjects/{subjectId:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> AddTeacherSubject(Guid teacherId, Guid subjectId)
    {
        var result = await _teacherService.AddTeacherSubjectAsync(teacherId, subjectId);
        return Ok(result);
    }

    [HttpDelete("{teacherId:guid}/subjects/{subjectId:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteTeacherSubject(Guid teacherId, Guid subjectId)
    {
        var result = await _teacherService.DeleteTeacherSubjectAsync(teacherId, subjectId);
        return Ok(result);
    }
}
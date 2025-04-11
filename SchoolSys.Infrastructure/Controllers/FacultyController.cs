using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.FacultyDto.Request;
using SchoolSys.Application.interfaces.Services;

namespace SchoolSys.Infrastructure.Controllers;

[ApiController]
[Route("api/faculties")]
public class FacultyController : ControllerBase
{
    private readonly IFacultyService _facultyService;

    public FacultyController(IFacultyService facultyService)
    {
        _facultyService = facultyService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Create([FromBody] CreateFacultyRequest request)
    {
        var facultyId = await _facultyService.AddAsync(request);
        return Ok(facultyId);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFacultyRequest request)
    {
        var result = await _facultyService.UpdateAsync(request);
        return result ? Ok() : NotFound("Faculty not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _facultyService.DeleteAsync(id);
        return result ? Ok() : NotFound("Faculty not found");
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var faculty = await _facultyService.GetByIdAsync(id);
        if (faculty == null)
            return NotFound("Faculty not found");

        return Ok(faculty);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetAll()
    {
        var faculties = await _facultyService.GetAllAsync();
        return Ok(faculties);
    }

    [HttpGet("{facultyId:guid}/teachers")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetTeachersByFacultyId(Guid facultyId)
    {
        var teachers = await _facultyService.GetTeachersByFacultyIdAsync(facultyId);
        return Ok(teachers);
    }
}
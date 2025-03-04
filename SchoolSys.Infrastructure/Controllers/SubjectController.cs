// SchoolSys.Web/Controllers/SubjectController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.SubjectDto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/subjects")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Create([FromBody] CreateSubjectRequest request)
    {
        var subjectId = await _subjectService.AddAsync(request);
        return Ok(subjectId);
    }

    [HttpPut("{Update")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Update([FromBody] UpdateSubjectRequest request)
    {
        var result = await _subjectService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _subjectService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var subject = await _subjectService.GetByIdAsync(id);
        return Ok(subject);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetAll()
    {
        var subjects = await _subjectService.GetAllAsync();
        return Ok(subjects);
    }
}
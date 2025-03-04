// SchoolSys.Web/Controllers/StudentController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/students")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
    {
        var studentId = await _studentService.AddAsync(request);
        return Ok(studentId);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Update([FromBody] UpdateStudentRequest request)
    {
        var result = await _studentService.UpdateAsync(request);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _studentService.DeleteAsync(id);
        return result ? Ok() : NotFound("Student not found");
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _studentService.GetByIdAsync(id);

        return Ok(student);
    }

    [HttpGet("{id:guid}/history")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetByIdWithHistory(Guid id)
    {
        var student = await _studentService.GetByIdWithHistoryAsync(id);

        return Ok(student);
    }

    [HttpGet]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetAll()
    {
        var students = await _studentService.GetStudentsByGroupIdAsync(Guid.Empty); // Замените на релевантный фильтр или GetAllAsync
        return Ok(students);
    }

    [HttpGet("by-year-faculty")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetStudentsByYearAndFaculty([FromQuery] int year, [FromQuery] Guid facultyId)
    {
        var students = await _studentService.GetStudentsByYearAndFacultyAsync(year, facultyId);
        return Ok(students);
    }

    [HttpGet("{id:guid}/history-simple")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetStudentByGetStudentHistoryByIdAsyncIdAsync(Guid id)
    {
        var student = await _studentService.GetStudentByGetStudentHistoryByIdAsyncIdAsync(id);

        return Ok(student);
    }

    [HttpGet("by-group/{groupId:guid}")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetStudentsByGroupId(Guid groupId)
    {
        var students = await _studentService.GetStudentsByGroupIdAsync(groupId);
        return Ok(students);
    }
}
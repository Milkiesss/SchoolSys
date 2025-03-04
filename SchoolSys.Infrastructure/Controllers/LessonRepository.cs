// SchoolSys.Web/Controllers/LessonController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.LessonDto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/lessons")]
public class LessonController : ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Create([FromBody] CreateLessonRequest request)
    {
        var lessonId = await _lessonService.AddAsync(request);
        return Ok(lessonId);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLessonRequest request)
    {
        request.Id = id; // Убедитесь, что Id совпадает
        var result = await _lessonService.UpdateAsync(request);
        return result ? Ok() : NotFound("Lesson not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _lessonService.DeleteAsync(id);
        return result ? Ok() : NotFound("Lesson not found");
    }

    [HttpGet("group/{groupId:guid}/week")]
    [Authorize(Roles = "Administrator, Teacher, Student")]
    public async Task<IActionResult> GetLessonsForGroupInWeek(Guid groupId)
    {
        var lessons = await _lessonService.GetLessonsForGroupInWeekAsync(groupId);
        return Ok(lessons);
    }

    [HttpGet("teacher/{teacherId:guid}/days/{days:int}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetTeacherLessonsCountInDays(Guid teacherId, int days)
    {
        var lessons = await _lessonService.GetTeacherLessonsCountInDaysAsync(teacherId, days);
        return Ok(lessons);
    }
}
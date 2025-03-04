// SchoolSys.Web/Controllers/SessionController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.interfaces.Services;

[ApiController]
[Route("api/sessions")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Create([FromBody] CreateSessionRequest request)
    {
        var sessionId = await _sessionService.AddAsync(request);
        return Ok(sessionId);
    }

    [HttpPut("Update")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Update([FromBody] UpdateSessionRequest request)
    {
        var result = await _sessionService.UpdateAsync(request);
        return result ? Ok() : NotFound("Session not found");
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _sessionService.DeleteAsync(id);
        return result ? Ok() : NotFound("Session not found");
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var session = await _sessionService.GetByIdAsync(id);
        if (session == null)
            return NotFound("Session not found");

        return Ok(session);
    }
    

    [HttpGet("by-group/{groupId:guid}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetSessionsByGroupId(Guid groupId)
    {
        var sessions = await _sessionService.GetSessionsByGroupIdAsync(groupId);
        return Ok(sessions);
    }

    [HttpGet("by-date/{date:datetime}")]
    [Authorize(Roles = "Administrator, Teacher")]
    public async Task<IActionResult> GetSessionsByDateRange(DateTime date)
    {
        var sessions = await _sessionService.GetSessionsByDateRangeAsync(date);
        return Ok(sessions);
    }
}
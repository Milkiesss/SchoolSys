// SchoolSys.Web/Controllers/SessionController.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.interfaces.Services;

namespace SchoolSys.Infrastructure.Controllers;
    
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
    
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Administrator,Teacher")]
        public async Task<IActionResult> Update(Guid id,[FromBody] UpdateSessionRequest request)
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
        public async Task<IActionResult> GetById(Guid id)//todo
        {
            var session = await _sessionService.GetByIdAsync(id);
            if (session == null)
                return NotFound("Session not found");
    
            return Ok(session);
        }
        
    
        [HttpGet("by-group")]
        [Authorize(Roles = "Administrator, Teacher")]
        public async Task<IActionResult> GetSessionsByGroupId(string groupName,DateTime Year)
        {
            var sessions = await _sessionService.GetSessionsByGroupIdAsync(groupName,Year);
            return Ok(sessions);
        }
        
}
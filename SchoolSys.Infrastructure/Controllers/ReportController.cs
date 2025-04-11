using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.SessionDto;
using SchoolSys.Application.interfaces.Services;

namespace SchoolSys.Infrastructure.Controllers;

[ApiController]
[Route("api/reports")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }
    [Authorize(Roles = "Administrator, Teacher")]
    [HttpPost]
    public async Task<IActionResult> GetSessionReport(BaseSessionDto session)
    {
        var report =  _reportService.GetSessionReport(session);
        return File(report, "application/pdf", "report.pdf");
    }
}
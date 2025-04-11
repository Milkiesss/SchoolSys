using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSys.Application.Dtos.SessionDto;

namespace SchoolSys.Application.interfaces.Services;

public interface IReportService
{
    public byte[] GetSessionReport(BaseSessionDto session);
}
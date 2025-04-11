using FastReport;
using FastReport.Export.PdfSimple;
using SchoolSys.Application.Dtos.SessionDto;
using SchoolSys.Application.interfaces.Services;

namespace SchoolSys.Application.Services;

public class ReportService : IReportService
{
    public byte[] GetSessionReport(BaseSessionDto session)
    {
        var report = new Report();
        var student = session.Subjects.FirstOrDefault().Students.ToList();
    
        string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports", "sample.frx");
        report.Load(reportPath);
        
        report.RegisterData(student, "Students");
        report.SetParameterValue("GroupNumber", session.groupNumber);
        report.SetParameterValue("Date", session.SessionDate.ToString("dd.MM.yyyy"));
        report.SetParameterValue("SubjectName", session.Subjects.FirstOrDefault()?.SubjectName ?? "N/A");
        report.SetParameterValue("ExamType", session.Subjects.FirstOrDefault()?.ExaminationStatus.ToString() ?? "N/A");
        report.SetParameterValue("IsIncludedInDiploma", session.Subjects.Any(s => s.IsIncludedInDiploma));
        report.Prepare();

        using (var stream = new MemoryStream())
        {
            using (var pdfExport = new PDFSimpleExport())
            {
                pdfExport.Export(report, stream);
                return stream.ToArray();
            }
        }
    }
}


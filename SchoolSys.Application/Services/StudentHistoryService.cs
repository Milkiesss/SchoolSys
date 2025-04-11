using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Services;

public class StudentHistoryService 
{
    private readonly IStudentHistoryRepository _studentHistoryRepository;

    public StudentHistoryService(IStudentHistoryRepository studentHistoryRepository)
    {
        _studentHistoryRepository = studentHistoryRepository;
    }

    public async Task RecordCreationAsync(Guid studentId)
    {
        var studentHistory = new StudentHistory()
        {
            StudentId = studentId,
            ChangeDate = DateTime.UtcNow,
            OldStatus = null,
            NewStatus = StudentStatus.Enrolled,
            Comment = "Student Enrolled"
        }; 
        await _studentHistoryRepository.AddAsync(studentHistory);
    }

    public async Task RecordStatusChangeAsync(Guid studentId, StudentStatus oldStatus, StudentStatus newStatus)
    {
        var studentHistory = new StudentHistory()
        {
            StudentId = studentId,
            ChangeDate = DateTime.UtcNow,
            OldStatus = oldStatus,
            NewStatus = newStatus,
            Comment = "Status changed from {oldStatus} to {newStatus}"
        }; 
        await _studentHistoryRepository.AddAsync(studentHistory);
    }
}
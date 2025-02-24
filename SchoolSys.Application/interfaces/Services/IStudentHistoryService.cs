using SchoolSys.Domain.enums;

namespace SchoolSys.Application.interfaces.Services;

public interface IStudentHistoryService
{
    public Task RecordCreationAsync(Guid studentId);
    public Task RecordStatusChangeAsync(Guid studentId, StudentStatus oldStatus, StudentStatus newStatus);
}
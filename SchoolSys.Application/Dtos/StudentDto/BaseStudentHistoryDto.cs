using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.StudentDto;

public class BaseStudentHistoryDto
{
    public Guid StudentId { get; set; }
    public DateTime ChangeDate { get; set; }
    public StudentStatus? OldStatus { get; set; }
    public StudentStatus NewStatus { get; set; }
    public string Comment { get; set; }
}
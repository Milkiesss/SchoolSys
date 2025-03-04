using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto;

public class BaseSessionDto
{
    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public int Grade { get; set; }
    public DateTime SessionDate { get; set; }
    public string Comments { get; set; }
    public SessionStatus Status { get; set; }
}
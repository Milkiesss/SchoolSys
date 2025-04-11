using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto.SessionStudentsDto;

public class BaseSessionStudentDto
{
    public Guid Id { get; set; }
    public Guid? StudentId { get; set; }
    public string? StudentName { get; set; }
    public int Grade { get; set; }
    public SessionStatus Status { get; set; }
}
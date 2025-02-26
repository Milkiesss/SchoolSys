using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.StudentDto;

public class BaseStudentDto
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Guid GroupId { get; set; }
    public StudentStatus Status { get; set; }
}
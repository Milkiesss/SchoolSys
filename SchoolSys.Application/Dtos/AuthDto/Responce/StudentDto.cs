using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.AuthDto.Responce;

public class StudentDto
{
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public GroupDto Group { get; set; }
    public StudentStatus Status { get; set; }
}
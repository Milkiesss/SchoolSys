

namespace SchoolSys.Application.Dtos.TeacherDto;

public class BaseTeacherDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<string> Subjects { get; set; }
}
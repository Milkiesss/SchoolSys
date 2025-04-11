using SchoolSys.Application.Dtos.StudentDto;
using SchoolSys.Application.Dtos.TeacherDto;

namespace SchoolSys.Application.Dtos.AuthDto.Responce;

public class LoginResponce
{
    public string Email { get; set; }
    public string Token { get; set; }
    public StudentDto Student { get; set; }
    public BaseTeacherDto Teacher { get; set; }
}
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.AuthDto.Request;

public class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
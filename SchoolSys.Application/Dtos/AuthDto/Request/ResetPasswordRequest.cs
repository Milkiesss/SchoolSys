using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.AuthDto.Request;

public class ResetPasswordRequest
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}
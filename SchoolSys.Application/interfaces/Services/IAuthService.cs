using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<string> LoginAsync(LoginRequest request);
    Task<bool> ResetPasswordAsync(string email, string newPassword);
}
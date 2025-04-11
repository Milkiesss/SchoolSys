using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Application.Dtos.AuthDto.Responce;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<LoginResponce> LoginAsync(LoginRequest request);
    Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
}
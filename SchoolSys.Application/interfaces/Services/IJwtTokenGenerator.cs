using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(User entity);
}
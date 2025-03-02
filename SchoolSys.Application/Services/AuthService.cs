using AutoMapper;
using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Application.interfaces.Services;
using SchoolSys.Domain.Entities;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Services;

public class AuthService : IAuthService
{
   private readonly IUserRepository _userRepository; 
   private readonly PasswordHasher  _passwordHasher;
   private readonly IMapper _mapper;
   private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public AuthService( PasswordHasher passwordHasher, IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
    {
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _mapper = mapper;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async  Task<bool> RegisterAsync(RegisterRequest request)
    {
        if(await _userRepository.GetByEmailAsync(request.Email) != null)
            throw new Exception("Email already exists");
        
        var user = _mapper.Map<User>(request);
        
        if (request.Role == Role.Student)
        {
            user.StudentId = await _userRepository.GetStudentByFullNameAsync(request.FullName);
        }
        else
        {
            user.TeacherId = await _userRepository.GetTeacherByFullNameAsync(request.FullName);
        }
        
        user.PasswordHash = await _passwordHasher.HashPassword(request.Password);
        
        return true;
    }

    public async  Task<string> LoginAsync(LoginRequest request)
    {
       var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null || !await _passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        return _jwtTokenGenerator.GenerateToken(user);
    }
    

    public async Task<bool> ResetPasswordAsync(string email, string newPassword)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null)
            return false;

        user.PasswordHash = await _passwordHasher.HashPassword(newPassword);
        return await _userRepository.UpdateAsync(user);
    }
}
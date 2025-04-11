using AutoMapper;
using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Application.Dtos.AuthDto.Responce;
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
            var student = await _userRepository.GetStudentByEmailAsync(request.Email);
            user.StudentId = student?.Id; // Присваиваем Id студента, если студент найден, иначе null
        }
        else 
        {
            var teacher = await _userRepository.GetTeacherByEmailAsync(request.Email);
            user.TeacherId = teacher?.Id; // Присваиваем Id учителя, если учитель найден, иначе null
        }
        
        user.PasswordHash = await _passwordHasher.HashPassword(request.Password);
        await _userRepository.AddAsync(user);
        return true;
    }

    public async  Task<LoginResponce> LoginAsync(LoginRequest request)
    {
       var user = await _userRepository.GetByEmailAsync(request.Email);
       if (user.StudentId is not null)
       {
           user.Student = await _userRepository.GetStudentByEmailAsync(request.Email);
       }
       else
       {
           user.Teacher = await _userRepository.GetTeacherByEmailAsync(request.Email);
       }
        if (user == null || !await _passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");
        
        var responce = _mapper.Map<LoginResponce>(user);
        responce.Token = _jwtTokenGenerator.GenerateToken(user);
        
        return responce;
    }
    

    public async Task<bool> ResetPasswordAsync(ResetPasswordRequest request)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
            return false;

        user.PasswordHash = await _passwordHasher.HashPassword(request.NewPassword);
        return await _userRepository.UpdateAsync(user);
    }
}
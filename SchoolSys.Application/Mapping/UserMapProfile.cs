using AutoMapper;
using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Application.Dtos.AuthDto.Responce;
using SchoolSys.Application.Dtos.GroupDto;
using SchoolSys.Application.Dtos.StudentDto;
using SchoolSys.Application.Dtos.TeacherDto;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<RegisterRequest,User>()
            .ConstructUsing(dto => new User(
                Guid.NewGuid(),
                dto.Email,
                dto.Role
            ))
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.TeacherId, opt => opt.Ignore())
            .ForMember(dest => dest.StudentId, opt => opt.Ignore());

        CreateMap<User, LoginResponce>();
        CreateMap<Student, StudentDto>();
        CreateMap<Teacher, BaseTeacherDto>();
        CreateMap<Group, GroupDto>();
    }
}
using AutoMapper;
using SchoolSys.Application.Dtos.AuthDto.Request;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class UserMapProfile : Profile
{
    public UserMapProfile()
    {
        CreateMap<RegisterRequest,User>()
            .ConstructUsing(dto => new User(
                Guid.NewGuid(),
                dto.FullName,
                dto.Email,
                dto.Role
            ));
        
    }
}
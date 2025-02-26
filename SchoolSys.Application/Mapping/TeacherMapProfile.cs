using AutoMapper;
using SchoolSys.Application.Dtos.TeacherDto.Request;
using SchoolSys.Application.Dtos.TeacherDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class TeacherMapProfile : Profile
{
    public TeacherMapProfile()
    {
        CreateMap<CreateTeacherRequest,Teacher>()
            .ConstructUsing(dto => new Teacher(
                Guid.NewGuid(),
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.PhoneNumber

            ));
            
        CreateMap<UpdateTeacherRequest,Teacher>()
            .ConstructUsing(dto => new Teacher(
                dto.Id,
                dto.FirstName,
                dto.LastName,
                dto.Email,
                dto.PhoneNumber
            ));
        
        CreateMap<Teacher, GetTeacherResponse>();
    }
}
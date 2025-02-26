using AutoMapper;
using SchoolSys.Application.Dtos.Groupto.Request;
using SchoolSys.Application.Dtos.Groupto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class GroupMapProfile : Profile
{
    public GroupMapProfile()
    {
        CreateMap<CreateGroupRequest,Group>()
            .ConstructUsing(dto => new Group(
                Guid.NewGuid(),
                dto.Name,
                dto.FacultyId,
                dto.Course
            ));
            
        CreateMap<UpdateGroupRequest,Group>()
            .ConstructUsing(dto => new Group(
                dto.Id,
                dto.Name,
                dto.FacultyId,
                dto.Course
            ));

        CreateMap<Group, GetGroupResponse>()
            .ForMember(dest => dest.StudentNames, opt => 
                opt.MapFrom(src => src.Students.Select(s => s.FullName)));
    }
}
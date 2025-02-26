using AutoMapper;
using SchoolSys.Application.Dtos.FacultyDto.Request;
using SchoolSys.Application.Dtos.FacultyDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class FacultyMapProfile : Profile
{
    public FacultyMapProfile()
    {
        CreateMap<CreateFacultyRequest,Faculty>()
            .ConstructUsing(dto => new Faculty(
                Guid.NewGuid(),
                dto.Name

            ));
            
        CreateMap<UpdateFacultyRequest ,Faculty>()
            .ConstructUsing(dto => new Faculty(
                dto.Id,
                dto.Name
            ));
        
        CreateMap<Faculty, GetFacultyResponse>();
    }
}
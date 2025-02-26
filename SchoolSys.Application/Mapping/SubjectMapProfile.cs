using AutoMapper;
using SchoolSys.Application.Dtos.SubjectDto.Request;
using SchoolSys.Application.Dtos.SubjectDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class SubjectMapProfile : Profile
{
    public SubjectMapProfile()
    {
        CreateMap<CreateSubjectRequest,Subject>()
            .ConstructUsing(dto => new Subject(
                Guid.NewGuid(),
                dto.Name,
                dto.FacultyId

            ));
            
        CreateMap<UpdateSubjectRequest,Subject>()
            .ConstructUsing(dto => new Subject(
                dto.Id,
                dto.Name,
                dto.FacultyId
            ));
        
        CreateMap<Subject, GetSubjectResponse>();
    }
}
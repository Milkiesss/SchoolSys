using AutoMapper;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.Dtos.SessionDto.Responce;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class SessionMapProfile : Profile
{
    public SessionMapProfile()
    {
        
        CreateMap<CreateSessionRequest,Session>()
            .ConstructUsing(dto => new Session(
                Guid.NewGuid(),
                dto.GroupId,
                dto.SubjectId,
                dto.Grade,
                dto.SessionDate,
                dto.Comments,
                dto.Status
            ));
            
        CreateMap<UpdateSessionRequest,Session>()
            .ConstructUsing(dto => new Session(
                dto.Id,
                dto.GroupId,
                dto.SubjectId,
                dto.Grade,
                dto.SessionDate,
                dto.Comments,
                dto.Status
            ));

        CreateMap<Session, GetSessionResponce>();
    }
}

using AutoMapper;
using SchoolSys.Application.Dtos.SessionDto;
using SchoolSys.Application.Dtos.SessionDto.Request;
using SchoolSys.Application.Dtos.SessionDto.Responce;
using SchoolSys.Application.Dtos.SessionDto.SessionStudentsDto;
using SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class SessionMapProfile : Profile
{
    public SessionMapProfile()
         {
             
             CreateMap<CreateSessionRequest, Session>()
                 .ConstructUsing(dto => new Session(
                     Guid.NewGuid(), 
                     dto.GroupId,
                     dto.SessionDate
                 ))
                 .ForMember(dest => dest.Subjects, opt => opt.Ignore());;


             CreateMap<UpdateSessionRequest, Session>()
                 .ConstructUsing(dto => new Session(
                     dto.Id,
                     dto.GroupId,
                     dto.SessionDate
                 ))
                 .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.Subjects));

             CreateMap<UpdateSessionSubjectRequest, SessionSubject>();
             CreateMap<UpdateSessionStudentRequest, SessionStudent>();
             
             CreateMap<Session, GetSessionResponce>()
                 .ForMember(dest => dest.groupNumber, opt => opt.MapFrom(src => src.Group.Name));

             // Маппинг SessionSubject -> BaseSessionSubjectDto
             CreateMap<SessionSubject, BaseSessionSubjectDto>()
                 .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));

             // Маппинг SessionStudent -> BaseSessionStudentDto
             CreateMap<SessionStudent, BaseSessionStudentDto>()
                 .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.Student.FullName));
         }
}
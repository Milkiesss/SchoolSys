using AutoMapper;
using SchoolSys.Application.Dtos.LessonDto.Request;
using SchoolSys.Application.Dtos.LessonDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class LessonMapProfile : Profile
{
    public LessonMapProfile()
    {
        CreateMap<CreateLessonRequest,Lesson>()
            .ConstructUsing(dto => new Lesson(
                Guid.NewGuid(),
                dto.SubjectId,
                dto.GroupId,
                dto.LessonDate,
                dto.TeacherId,
                dto.Room
            ));
            
        CreateMap<UpdateLessonRequest,Lesson>()
            .ConstructUsing(dto => new Lesson(
                dto.Id,
                dto.SubjectId,
                dto.GroupId,
                dto.LessonDate,
                dto.TeacherId,
                dto.Room
            ));
        
        CreateMap<Lesson, GetLessonResponse>();
    }
}
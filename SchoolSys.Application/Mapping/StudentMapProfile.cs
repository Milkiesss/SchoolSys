using AutoMapper;
using SchoolSys.Application.Dtos.StudentDto;
using SchoolSys.Application.Dtos.StudentDto.Request;
using SchoolSys.Application.Dtos.StudentDto.Response;
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.Mapping;

public class StudentMapProfile : Profile
{
    public StudentMapProfile()
    {
        CreateMap<CreateStudentRequest,Student>()
            .ConstructUsing(dto => new Student(
                Guid.NewGuid(),
                dto.FullName,
                dto.Gender,
                dto.Email,
                dto.DateOfBirth,
                dto.Status,
                dto.GroupId
            ));
            
        CreateMap<UpdateStudentRequest,Student>()
            .ConstructUsing(dto => new Student(
                dto.Id,
                dto.FullName,
                dto.Gender,
                dto.Email,
                dto.DateOfBirth,
                dto.Status,
                dto.GroupId
            ));
        CreateMap<Student, GetStudentWithHistoryResponse>();
        CreateMap<Student, GetStudentResponse>();
        CreateMap<StudentHistory, BaseStudentHistoryDto>();
    }
}
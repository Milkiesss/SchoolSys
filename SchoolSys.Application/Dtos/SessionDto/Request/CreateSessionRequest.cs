using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto.Request;

public class CreateSessionRequest 
{
    public string groupNumber { get; set; }
    public DateTime SessionDate { get; set; }
    [JsonIgnore]
    public  Guid GroupId { get; set; }
    
    public ICollection<string>? Subjects { get; set; }
}
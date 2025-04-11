using SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto;

public class BaseSessionDto
{
    public Guid GroupId { get; set; }
    public string groupNumber { get; set; }
    public DateTime SessionDate { get; set; }
    public List<BaseSessionSubjectDto>? Subjects { get; set; } = new List<BaseSessionSubjectDto>();
}
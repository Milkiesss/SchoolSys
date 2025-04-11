using SchoolSys.Application.Dtos.SessionDto.SessionStudentsDto;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;

public class BaseSessionSubjectDto
{
    public Guid Id { get; set; }
    public Guid? SessionId { get; set; }
    public Guid? SubjectId { get; set; }
    public string? SubjectName { get; set; }
    public bool IsIncludedInDiploma { get; set; }
    public ExaminationStatus ExaminationStatus { get; set; }
    public ICollection<BaseSessionStudentDto> Students { get; set; } = new List<BaseSessionStudentDto>();
}
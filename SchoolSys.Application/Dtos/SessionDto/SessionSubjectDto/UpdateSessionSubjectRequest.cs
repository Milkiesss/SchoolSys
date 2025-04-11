using SchoolSys.Application.Dtos.SessionDto.SessionStudentsDto;
using SchoolSys.Domain.enums;

namespace SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;

public class UpdateSessionSubjectRequest
{
    public Guid Id { get; set; }
    public Guid? SessionId { get; set; }
    public Guid? SubjectId { get; set; }
    public bool IsIncludedInDiploma { get; set; }
    public ExaminationStatus ExaminationStatus { get; set; }
    public ICollection<UpdateSessionStudentRequest> Students { get; set; }
}
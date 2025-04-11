using SchoolSys.Application.Dtos.SessionDto.SessionSubjectDto;

namespace SchoolSys.Application.Dtos.SessionDto.Request;

public class UpdateSessionRequest : BaseSessionDto
{
    public Guid Id { get; set; }
    public DateTime SessionDate { get; set; }
    public ICollection<UpdateSessionSubjectRequest>? Subjects { get; set; }
}
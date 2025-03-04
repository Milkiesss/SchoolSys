using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class Session : BaseEntity
{
    public Session(Guid Id, Guid dtoGroupId, Guid dtoSubjectId, int dtoGrade, DateTime dtoSessionDate, string dtoComments, SessionStatus dtoStatus)
    {
        SetId(Id);
        GroupId = dtoGroupId;
        SubjectId = dtoSubjectId;
        Grade = dtoGrade;
        SessionDate = dtoSessionDate;
        Comments = dtoComments;
        Status = dtoStatus;
    }

    public Guid GroupId { get; set; } 
    public Guid SubjectId { get; set; }
    public int Grade { get; set; } 
    public DateTime SessionDate { get; set; } 
    public string Comments { get; set; } 
    public SessionStatus Status { get; set; } 
    
    public Group Group { get; set; }
    public Subject Subject { get; set; }
}
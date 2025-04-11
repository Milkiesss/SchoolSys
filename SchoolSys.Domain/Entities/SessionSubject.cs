using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class SessionSubject : BaseEntity
{
    public Guid SessionId { get; set; }
    public Session Session { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; }
    
    public bool IsIncludedInDiploma { get; set; }
    
    public ExaminationStatus ExaminationStatus { get; set; }
    public List<SessionStudent>? Students { get; set; }
    public SessionSubject(Guid Id,Guid sessionId, Guid subjectId)
    {
        SetId(Id);
        SessionId = sessionId;
        SubjectId = subjectId;
    }
    public SessionSubject()
    {}
}
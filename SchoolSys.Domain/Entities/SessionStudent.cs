using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class SessionStudent : BaseEntity
{
    public Guid SessionSubjectId { get; set; }
    public SessionSubject SessionSubject { get; set; } 
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public int Grade { get; set; } = 0;
    public SessionStatus Status { get; set; } = 0;
    public SessionStudent(Guid sessionSubjectId, Guid studentId)
    {
        Id = Guid.NewGuid();
        SessionSubjectId = sessionSubjectId;
        StudentId = studentId;
        Grade = 0;
        Status = SessionStatus.Pending;
    }

    public SessionStudent()
    {
    }
}
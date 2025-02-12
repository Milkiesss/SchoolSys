namespace SchoolSys.Domain.Entities;

public class TeacherSubject
{
    public Teacher Teacher { get; set; }
    public Subject Subject { get; set; }
    public Guid  TeacherId {get;set;}
    public Guid SubjectId {get;set;}
}
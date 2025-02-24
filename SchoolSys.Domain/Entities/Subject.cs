namespace SchoolSys.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } 
    public Guid FacultyId { get; set; }
    public  Faculty Faculty { get; set; } 
    public  ICollection<TeacherSubject> TeacherSubjects { get; set; }
}
namespace SchoolSys.Domain.Entities;

public class Teacher : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public  ICollection<TeacherSubject> TeacherSubjects { get; set; } // Связь с предметами
    public  ICollection<Group> Groups { get; set; } // Группы, которые он курирует
}
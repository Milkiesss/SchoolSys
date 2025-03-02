namespace SchoolSys.Domain.Entities;

public class Teacher : BaseEntity
{
    public Teacher(Guid Id, string dtoFullName, string dtoEmail, string dtoPhoneNumber)
    {
        SetId(Id);
        FullName = dtoFullName;
        Email = dtoEmail;
        PhoneNumber = dtoPhoneNumber;   
    }

    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public  ICollection<TeacherSubject> TeacherSubjects { get; set; } // Связь с предметами
    public  ICollection<Group> Groups { get; set; } // Группы, которые он курирует
}
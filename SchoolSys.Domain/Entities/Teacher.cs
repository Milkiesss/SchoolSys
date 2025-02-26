namespace SchoolSys.Domain.Entities;

public class Teacher : BaseEntity
{
    public Teacher(Guid Id, string dtoFirstName, string dtoLastName, string dtoEmail, string dtoPhoneNumber)
    {
        SetId(Id);
        FirstName = dtoFirstName;
        LastName = dtoLastName;
        Email = dtoEmail;
        PhoneNumber = dtoPhoneNumber;   
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public  ICollection<TeacherSubject> TeacherSubjects { get; set; } // Связь с предметами
    public  ICollection<Group> Groups { get; set; } // Группы, которые он курирует
}
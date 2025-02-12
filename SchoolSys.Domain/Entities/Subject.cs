namespace SchoolSys.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } // Название предмета (например, "Математика")
    public Guid FacultyId { get; set; }
    public  Faculty Faculty { get; set; } // Факультет, к которому относится предмет
    public  ICollection<TeacherSubject> TeacherSubjects { get; set; }
}
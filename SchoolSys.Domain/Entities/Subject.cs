namespace SchoolSys.Domain.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } // Название предмета (например, "Математика")
    public int FacultyId { get; set; }
    public virtual Faculty Faculty { get; set; } // Факультет, к которому относится предмет
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
}
using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Guid GroupId { get; set; }
    public StudentStatus Status { get; set; } // Поступил, Переведен, В академ. отпуске, Отчислен
    public  Group Group { get; set; }
    public  ICollection<StudentHistory>? History { get; set; }
}
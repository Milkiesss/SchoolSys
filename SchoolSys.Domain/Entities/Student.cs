using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class Student : BaseEntity
{
    public Student(Guid Id, string email, string dtoFullName, string dtoGender, DateTime dtoDateOfBirth,
        StudentStatus dtoStatus, Guid dtoGroupId)
    {
        SetId(Id);
        FullName = dtoFullName;
        Gender = dtoGender;
        DateOfBirth = dtoDateOfBirth;
        Status = dtoStatus;
        GroupId = dtoGroupId;
        Email = email;
    }

    public Student()
    {
    }
    public string FullName { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; }
    public Guid GroupId { get; set; }
    public StudentStatus Status { get; set; } // Поступил, Переведен, В академ. отпуске, Отчислен
    public  Group Group { get; set; }
    public  ICollection<StudentHistory>? History { get; set; }
}
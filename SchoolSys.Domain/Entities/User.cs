using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class User : BaseEntity
{
    public User(Guid Id, string dtoFullName, string dtoEmail, Role dtoRole)
    {
        SetId(Id);
        FullName = dtoFullName;
        Email = dtoEmail;
        Role = dtoRole;
    }

    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public string FullName { get; set; }
    public Guid? TeacherId { get; set; } 
    public Guid? StudentId { get; set; } 

    public Teacher Teacher { get; set; } 
    public Student Student { get; set; } 
}
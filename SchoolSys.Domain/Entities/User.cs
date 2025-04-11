using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class User : BaseEntity
{
    public User(Guid id, string dtoEmail, Role dtoRole)
    {
        SetId(id);
        Email = dtoEmail;
        Role = dtoRole;
    }

    public User()
    {
    }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public Guid? TeacherId { get; set; } 
    public Guid? StudentId { get; set; } 

    public Teacher Teacher { get; set; } 
    public Student Student { get; set; } 
}
namespace SchoolSys.Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public int Course { get; set; }
    public int FacultyId { get; set; }
    public virtual Faculty Faculty { get; set; }
    public virtual ICollection<Student> Students { get; set; }
}
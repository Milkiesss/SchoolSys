namespace SchoolSys.Domain.Entities;

public class Group : BaseEntity
{
    public string Name { get; set; }
    public int Course { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public ICollection<Student> Students { get; set; }
}
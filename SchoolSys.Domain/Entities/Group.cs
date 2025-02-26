namespace SchoolSys.Domain.Entities;

public class Group : BaseEntity
{
    public Group(Guid Id, string dtoName, Guid dtoFacultyId, int dtoCourse)
    {
        SetId(Id);
        Name = dtoName;
        FacultyId = dtoFacultyId;
        Course = dtoCourse;
    }

    public string Name { get; set; }
    public int Course { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
    public ICollection<Student> Students { get; set; }
}
namespace SchoolSys.Application.Dtos.GroupDto;

public class BaseGroupDto
{
    public string Name { get; set; }
    public int Course { get; set; }
    public Guid FacultyId { get; set; }
}
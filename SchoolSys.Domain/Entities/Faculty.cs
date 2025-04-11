namespace SchoolSys.Domain.Entities;

public class Faculty : BaseEntity
{
    public Faculty(Guid Id, string dtoName)
    {
        SetId(Id); 
        Name = dtoName;
    }
    public Faculty(){}

    public string Name { get; set; }
    public ICollection<Group> Groups { get; set; }
}
namespace SchoolSys.Application.Dtos.Groupto.Response;

public class GetGroupResponse : BaseGroupDto
{
    public Guid Id { get; set; }
    public List<string> StudentNames { get; set; }
}
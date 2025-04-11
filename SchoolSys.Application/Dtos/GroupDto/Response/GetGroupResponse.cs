namespace SchoolSys.Application.Dtos.GroupDto.Response;

public class GetGroupResponse : BaseGroupDto
{
    public Guid Id { get; set; }
    public List<string> StudentNames { get; set; }
}
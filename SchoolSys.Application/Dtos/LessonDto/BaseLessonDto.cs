namespace SchoolSys.Application.Dtos.LessonDto;

public class BaseLessonDto
{
    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime LessonDate { get; set; }
    public string Room { get; set; }
}
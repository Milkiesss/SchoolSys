namespace SchoolSys.Domain.Entities;

public class Lesson : BaseEntity
{
    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime LessonDate { get; set; } // Дата и время занятия
    public string Room { get; set; } // Аудитория
    public Group Group { get; set; }
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
}
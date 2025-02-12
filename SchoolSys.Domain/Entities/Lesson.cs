namespace SchoolSys.Domain.Entities;

public class Lesson : BaseEntity
{
    public int GroupId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public DateTime LessonDate { get; set; } // Дата и время занятия
    public string Room { get; set; } // Аудитория
    public virtual Group Group { get; set; }
    public virtual Subject Subject { get; set; }
    public virtual Teacher Teacher { get; set; }
}
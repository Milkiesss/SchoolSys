namespace SchoolSys.Domain.Entities;

public class Lesson : BaseEntity
{
    public Lesson(Guid Id, Guid dtoSubjectId, Guid dtoGroupId, DateTime dtoLessonDate, Guid dtoTeacherId, string dtoRoom)
    {
        SetId(Id);
        SubjectId = dtoSubjectId;
        GroupId = dtoGroupId;
        LessonDate = dtoLessonDate;
        TeacherId = dtoTeacherId;
        Room = dtoRoom;
    }

    public Lesson()
    {
    }

    public Guid GroupId { get; set; }
    public Guid SubjectId { get; set; }
    public Guid TeacherId { get; set; }
    public DateTime LessonDate { get; set; } // Дата и время занятия
    public string Room { get; set; } // Аудитория
    public Group Group { get; set; }
    public Subject Subject { get; set; }
    public Teacher Teacher { get; set; }
}
using SchoolSys.Domain.enums;

namespace SchoolSys.Domain.Entities;

public class Session : BaseEntity
{

    public Session()
    {
    }

    public Session(Guid id, Guid groupId, DateTime dtoSessionDate)
    {
        SetId(id);
        GroupId = groupId;
        SessionDate = dtoSessionDate;
    }

    public Guid GroupId { get; set; } 
    public Group Group { get; set; }
    public DateTime SessionDate { get; set; } 
    public ICollection<SessionSubject> Subjects { get; set; }
}
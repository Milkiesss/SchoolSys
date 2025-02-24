using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ILessonRepository : IBaseRepository<Lesson>
{
    public Task<ICollection<Lesson>> GetLessonsByGroupIdAsync(Guid groupId);
    public Task<ICollection<Lesson>> GetLessonsByTeacherIdAsync(Guid TeacherId);
}
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ILessonRepository : IBaseRepository<Lesson>
{
     Task<ICollection<Lesson>> GetLessonsByGroupIdAsync(Guid groupId);
     Task<ICollection<Lesson>> GetTeacherLessonsCountInDaysAsync(Guid teacherId, int days);

}
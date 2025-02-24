using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface ITeacherRepository: IBaseRepository<Teacher>
{
    public Task<ICollection<Teacher>> GetTeachersByFacultyIdAsync(Guid facultyId);
    public Task<bool> AddTeacherSubjectAsync(Guid teacherId, Guid subjectId);
    public Task<bool> DeleteTeacherSubjectAsync(Guid teacherId, Guid subjectId);
}
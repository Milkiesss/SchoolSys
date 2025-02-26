using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IFacultyRepository : IBaseRepository<Faculty>
{
    Task<ICollection<Teacher>> GetTeachersByFacultyIdAsync(Guid facultyId);
}
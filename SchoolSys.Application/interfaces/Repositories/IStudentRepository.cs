using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IStudentRepository : IBaseRepository<Student>
{
    public Task<ICollection<Student>> GetStudentsByGroupIdAsync(Guid groupId);
    public Task<List<Student>> GetStudentHistoryByIdAsync(Guid studentId);
}
using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IStudentRepository : IBaseRepository<Student>
{
    public Task<Student> GetStudentHistoryByIdAsync(Guid studentId);
    Task<ICollection<Student>> GetStudentsByFacultyAndByYearAsync(int year, Guid facultyId);
    Task<ICollection<Student>> GetStudentsByGroupNameAsync(string groupName);
}
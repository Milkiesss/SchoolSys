using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<Student> GetStudentByEmailAsync(string fullName);
    Task<Teacher> GetTeacherByEmailAsync(string fullName);

}
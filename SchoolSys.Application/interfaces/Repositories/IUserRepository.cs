using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
    Task<Guid> GetStudentByFullNameAsync(string fullName);
    Task<Guid> GetTeacherByFullNameAsync(string fullName);

}
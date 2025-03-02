using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Guid> GetStudentByFullNameAsync(string fullName)
    {
        var result = await _context.Students.FirstOrDefaultAsync(x=>x.FullName == fullName);
        if (result == null)
            throw new Exception("Student not found");
        return result.Id;
    }

    public async Task<Guid> GetTeacherByFullNameAsync(string fullName)
    {
        var result = await _context.Teachers.FirstOrDefaultAsync(x=>x.FullName == fullName);
        if(result == null)
            throw new Exception("Teacher not found");
        return result.Id;
    }
    
}
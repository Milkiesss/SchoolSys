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
        return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Student> GetStudentByEmailAsync(string email)
    {
        var result = await _context.Students.AsNoTracking()
            .Include(s=>s.Group)
            .FirstOrDefaultAsync(x=>x.Email == email);
        if (result == null)
            throw new Exception("Student not found");
        return result;
    }

    public async Task<Teacher> GetTeacherByEmailAsync(string email)
    {
        var result = await _context.Teachers.AsNoTracking()
            .Include(t=>t.TeacherSubjects)
            .FirstOrDefaultAsync(x=>x.Email == email);
        if(result == null)
            throw new Exception("Teacher not found");
        return result;
    }
    
}
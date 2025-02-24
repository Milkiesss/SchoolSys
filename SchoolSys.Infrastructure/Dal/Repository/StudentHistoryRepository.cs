using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class StudentHistoryRepository : BaseRepository<StudentHistory>, IStudentHistoryRepository
{
    public StudentHistoryRepository(DataContext context) : base(context)
    {
    }
}
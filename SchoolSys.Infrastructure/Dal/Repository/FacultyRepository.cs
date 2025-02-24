
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class FacultyRepository: BaseRepository<Faculty>, IFacultyRepository 
{
    public FacultyRepository(DataContext context) : base(context) {}
}
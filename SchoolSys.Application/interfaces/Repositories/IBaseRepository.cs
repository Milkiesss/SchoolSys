using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<ICollection<T>> GetAllAsync();
    Task AddAsync(T entity);
    bool Update(T entity);
    bool Delete(T entity);
    Task SaveChangesAsync();
}
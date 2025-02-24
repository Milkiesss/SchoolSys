using SchoolSys.Domain.Entities;

namespace SchoolSys.Application.interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<ICollection<T>> GetAllAsync();
    Task<Guid> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task SaveChangesAsync();
}
using Microsoft.EntityFrameworkCore;
using SchoolSys.Application.interfaces.Repositories;
using SchoolSys.Domain.Entities;
using SchoolSys.Infrastructure.Dal.EntityFramework;

namespace SchoolSys.Infrastructure.Dal.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly DataContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DataContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(x=>x.Id==id);
    }

    public async Task<ICollection<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<Guid> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync();
        return true;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
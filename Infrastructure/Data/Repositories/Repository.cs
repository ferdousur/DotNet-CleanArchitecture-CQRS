using CleanMediator.CommonForPagination;
using CleanMediator.Extensions;
using CleanMediator.Infrastructure.Data.AppDbContext;
using CleanMediator.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CleanMediator.Infrastructure.Repository;
public class Repository<T> : IRepository<T> where T: class
{
    private readonly AppDbContext _context; 
    private readonly DbSet<T> _dbSet; 

    public Repository(AppDbContext context)
    {
        _context=context;
        _dbSet=_context.Set<T>(); 
    }

    public async Task<T> CreateAsync(T entity)
    {
        await _context.AddAsync(entity); 
        return entity; 
    }
    public async Task<PagedResult<T>> GetAllAsync(PaginationParams input)
    {
        IQueryable<T> query= _dbSet.AsNoTracking(); 
        return await _dbSet.ToPagedResultAsync(input.PageNumber, input.PageSize);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _context.Remove(entity);

        return true; 
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return   await _dbSet.FindAsync(id);
    }

    public async Task<T> UpdateAsync(int id, T entity)
    {
        var existingEntity =  await _dbSet.FindAsync(id); 
        if (existingEntity == null)
        return null!;

        _context.Entry(existingEntity).CurrentValues.SetValues(entity); 

        return existingEntity;
    }
}


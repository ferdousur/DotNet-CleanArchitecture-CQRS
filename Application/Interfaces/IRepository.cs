using CleanMediator.CommonForPagination;

namespace CleanMediator.Interfaces; 

public interface IRepository<T>
{
    Task<T> CreateAsync(T entity);
    Task<PagedResult<T>> GetAllAsync(PaginationParams input);
    Task SaveChangesAsync();
    Task<bool> DeleteAsync(int id);
    Task<T?> GetByIdAsync(int id);
    Task<T> UpdateAsync(int id, T entity);
}
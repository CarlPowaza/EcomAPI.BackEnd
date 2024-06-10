using System.Linq.Expressions;

public interface IRepository<T>
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task CreateAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
    Task<List<T>> FindAsync(Expression<Func<T, bool>> filter);
}
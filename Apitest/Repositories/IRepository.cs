using System.Linq.Expressions;

namespace Apitest.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(int page, int pageSize, CancellationToken ct);
    Task<int> CountAsync(CancellationToken ct);
    Task<T?> GetByIdAsync(int id, CancellationToken ct);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct);
    void Add(T entity);
    void Remove(T entity);
    Task SaveChangesAsync(CancellationToken ct);
}

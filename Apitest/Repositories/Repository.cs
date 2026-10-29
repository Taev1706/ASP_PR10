using Apitest.Common;
using System.Linq.Expressions;
using Apitest.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public abstract class Repository<T>(ShopBdContext context, string keyName) : IRepository<T> where T : class
{
    protected ShopBdContext Context { get; } = context;
    protected virtual IQueryable<T> ReadQuery => Context.Set<T>();

    public Task<List<T>> GetAllAsync(int page, int pageSize, CancellationToken ct) =>
        ReadQuery.AsNoTracking().OrderBy(e => EF.Property<int>(e, keyName))
            .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync(ct);

    public Task<int> CountAsync(CancellationToken ct) => Context.Set<T>().CountAsync(ct);

    public Task<T?> GetByIdAsync(int id, CancellationToken ct) =>
        ReadQuery.FirstOrDefaultAsync(e => EF.Property<int>(e, keyName) == id, ct);

    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken ct) =>
        Context.Set<T>().AnyAsync(predicate, ct);

    public void Add(T entity) => Context.Set<T>().Add(entity);
    public void Remove(T entity) => Context.Set<T>().Remove(entity);

    public async Task SaveChangesAsync(CancellationToken ct)
    {
        try
        {
            await Context.SaveChangesAsync(ct);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new DataConflictException("Данные уже изменены другим запросом. Обновите данные и повторите операцию.");
        }
        catch (DbUpdateException ex) when (ex.InnerException is SqlException sql &&
            (sql.Number == 2601 || sql.Number == 2627 || sql.Number == 547))
        {
            throw new DataConflictException("Нельзя сохранить изменения: нарушена уникальность, связь или ограничение данных.");
        }
    }
}

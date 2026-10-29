namespace Apitest.Services;

public interface IService<TRead, TCreate, TUpdate, TPatch>
{
    Task<(List<TRead> Items, int TotalCount)> GetAllAsync(int page, int pageSize, CancellationToken ct);
    Task<TRead> GetByIdAsync(int id, CancellationToken ct);
    Task<TRead> CreateAsync(TCreate dto, CancellationToken ct);
    Task UpdateAsync(int id, TUpdate dto, CancellationToken ct);
    Task PatchAsync(int id, TPatch dto, CancellationToken ct);
    Task DeleteAsync(int id, CancellationToken ct);
}

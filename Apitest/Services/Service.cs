using Apitest.Common;
using AutoMapper;
using Apitest.Repositories;

namespace Apitest.Services;

public abstract class Service<TEntity, TRead, TCreate, TUpdate, TPatch>(
    IRepository<TEntity> repository, IMapper mapper) : IService<TRead, TCreate, TUpdate, TPatch>
    where TEntity : class
{
    protected IRepository<TEntity> Repository { get; } = repository;
    protected IMapper Mapper { get; } = mapper;
    protected abstract int GetId(TEntity entity);
    protected virtual void Initialize(TEntity entity) { }
    protected virtual Task ValidateAsync(TEntity entity, CancellationToken ct) => Task.CompletedTask;
    protected virtual Task ValidateDeleteAsync(TEntity entity, CancellationToken ct) => Task.CompletedTask;

    public async Task<(List<TRead> Items, int TotalCount)> GetAllAsync(int page, int pageSize, CancellationToken ct)
    {
        if (page < 1 || pageSize < 1 || pageSize > 100 || (long)(page - 1) * pageSize > int.MaxValue)
            throw new BusinessRuleException("page должен быть положительным, pageSize — от 1 до 100; номер страницы слишком велик.");
        var entities = await Repository.GetAllAsync(page, pageSize, ct);
        var total = await Repository.CountAsync(ct);
        return (Mapper.Map<List<TRead>>(entities), total);
    }

    public async Task<TRead> GetByIdAsync(int id, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct)
            ?? throw new ResourceNotFoundException("Запись не найдена.");
        return Mapper.Map<TRead>(entity);
    }

    public virtual async Task<TRead> CreateAsync(TCreate dto, CancellationToken ct)
    {
        var entity = Mapper.Map<TEntity>(dto);
        Initialize(entity);
        await ValidateAsync(entity, ct);
        Repository.Add(entity);
        await Repository.SaveChangesAsync(ct);
        return await GetByIdAsync(GetId(entity), ct);
    }

    public virtual async Task UpdateAsync(int id, TUpdate dto, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct)
            ?? throw new ResourceNotFoundException("Запись не найдена.");
        Mapper.Map(dto, entity);
        await ValidateAsync(entity, ct);
        await Repository.SaveChangesAsync(ct);
    }

    public virtual async Task PatchAsync(int id, TPatch dto, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct)
            ?? throw new ResourceNotFoundException("Запись не найдена.");
        Mapper.Map(dto, entity);
        await ValidateAsync(entity, ct);
        await Repository.SaveChangesAsync(ct);
    }

    public virtual async Task DeleteAsync(int id, CancellationToken ct)
    {
        var entity = await Repository.GetByIdAsync(id, ct)
            ?? throw new ResourceNotFoundException("Запись не найдена.");
        await ValidateDeleteAsync(entity, ct);
        Repository.Remove(entity);
        await Repository.SaveChangesAsync(ct);
    }
}

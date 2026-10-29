using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class CategoryService(ICategoryRepository repository, IMapper mapper,
    IProductRepository productRepository) : Service<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto, PatchCategoryDto>(repository, mapper), ICategoryService
{
    protected override int GetId(Category entity) => entity.CategoryId;

    protected override async Task ValidateDeleteAsync(Category entity, CancellationToken ct)
    {
        if (await productRepository.AnyAsync(e => e.CategoryId == entity.CategoryId, ct))
            throw new DataConflictException("Сначала удалите связанные записи Product.");
    }
}

using Apitest.Dtos;

namespace Apitest.Services;

public interface ICategoryService : IService<CategoryDto, CreateCategoryDto, UpdateCategoryDto, PatchCategoryDto>
{
}

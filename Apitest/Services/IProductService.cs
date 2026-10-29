using Apitest.Dtos;

namespace Apitest.Services;

public interface IProductService : IService<ProductDto, CreateProductDto, UpdateProductDto, PatchProductDto>
{
}

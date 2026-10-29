using Apitest.Dtos;

namespace Apitest.Services;

public interface ICartItemService : IService<CartItemDto, CreateCartItemDto, UpdateCartItemDto, PatchCartItemDto>
{
}

using Apitest.Dtos;

namespace Apitest.Services;

public interface ICartService : IService<CartDto, CreateCartDto, UpdateCartDto, PatchCartDto>
{
}

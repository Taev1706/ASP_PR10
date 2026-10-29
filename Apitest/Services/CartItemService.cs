using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class CartItemService(ICartItemRepository repository, IMapper mapper,
    ICartRepository cartRepository,
    IProductRepository productRepository) : Service<CartItem, CartItemDto, CreateCartItemDto, UpdateCartItemDto, PatchCartItemDto>(repository, mapper), ICartItemService
{
    protected override int GetId(CartItem entity) => entity.CartItemId;

    protected override async Task ValidateAsync(CartItem entity, CancellationToken ct)
    {
        if (!await cartRepository.AnyAsync(e => e.CartId == entity.CartId, ct))
            throw new BusinessRuleException("Связанная запись Cart не найдена.");
        if (!await productRepository.AnyAsync(e => e.ProductId == entity.ProductId, ct))
            throw new BusinessRuleException("Связанная запись Product не найдена.");
    }
}

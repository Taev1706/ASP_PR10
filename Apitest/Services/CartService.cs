using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class CartService(ICartRepository repository, IMapper mapper,
    ICartItemRepository cartItemRepository,
    IUserRepository userRepository) : Service<Cart, CartDto, CreateCartDto, UpdateCartDto, PatchCartDto>(repository, mapper), ICartService
{
    protected override int GetId(Cart entity) => entity.CartId;

    protected override async Task ValidateAsync(Cart entity, CancellationToken ct)
    {
        if (!await userRepository.AnyAsync(e => e.UserId == entity.UserId, ct))
            throw new BusinessRuleException("Связанная запись User не найдена.");
        if (await repository.AnyAsync(e => e.UserId == entity.UserId && e.CartId != entity.CartId, ct))
            throw new DataConflictException("У пользователя уже есть корзина.");
    }

    protected override async Task ValidateDeleteAsync(Cart entity, CancellationToken ct)
    {
        if (await cartItemRepository.AnyAsync(e => e.CartId == entity.CartId, ct))
            throw new DataConflictException("Сначала удалите связанные записи CartItem.");
    }
}

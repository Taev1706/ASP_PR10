using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class OrderService(IOrderRepository repository, IMapper mapper,
    IOrderItemRepository orderItemRepository,
    IUserRepository userRepository) : Service<Order, OrderDto, CreateOrderDto, UpdateOrderDto, PatchOrderDto>(repository, mapper), IOrderService
{
    protected override int GetId(Order entity) => entity.OrderId;

    protected override void Initialize(Order entity)
    {
        entity.OrderDate ??= DateTime.UtcNow;
        entity.Status ??= "New";
    }

    protected override async Task ValidateAsync(Order entity, CancellationToken ct)
    {
        if (!await userRepository.AnyAsync(e => e.UserId == entity.UserId, ct))
            throw new BusinessRuleException("Связанная запись User не найдена.");
    }

    protected override async Task ValidateDeleteAsync(Order entity, CancellationToken ct)
    {
        if (await orderItemRepository.AnyAsync(e => e.OrderId == entity.OrderId, ct))
            throw new DataConflictException("Сначала удалите связанные записи OrderItem.");
    }
}

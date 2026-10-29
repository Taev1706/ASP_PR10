using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class OrderItemService(IOrderItemRepository repository, IMapper mapper,
    IOrderRepository orderRepository,
    IProductRepository productRepository) : Service<OrderItem, OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto, PatchOrderItemDto>(repository, mapper), IOrderItemService
{
    protected override int GetId(OrderItem entity) => entity.OrderItemId;

    protected override async Task ValidateAsync(OrderItem entity, CancellationToken ct)
    {
        if (!await orderRepository.AnyAsync(e => e.OrderId == entity.OrderId, ct))
            throw new BusinessRuleException("Связанная запись Order не найдена.");
        if (!await productRepository.AnyAsync(e => e.ProductId == entity.ProductId, ct))
            throw new BusinessRuleException("Связанная запись Product не найдена.");
    }
}

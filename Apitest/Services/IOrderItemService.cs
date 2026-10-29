using Apitest.Dtos;

namespace Apitest.Services;

public interface IOrderItemService : IService<OrderItemDto, CreateOrderItemDto, UpdateOrderItemDto, PatchOrderItemDto>
{
}

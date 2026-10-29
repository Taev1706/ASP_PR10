using Apitest.Dtos;

namespace Apitest.Services;

public interface IOrderService : IService<OrderDto, CreateOrderDto, UpdateOrderDto, PatchOrderDto>
{
}

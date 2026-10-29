using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class OrderItemRepository(ShopBdContext context) : Repository<OrderItem>(context, "OrderItemId"), IOrderItemRepository
{
    protected override IQueryable<OrderItem> ReadQuery => Context.Set<OrderItem>().Include(e => e.Order).Include(e => e.Product);
}

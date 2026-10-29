using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class OrderRepository(ShopBdContext context) : Repository<Order>(context, "OrderId"), IOrderRepository
{
    protected override IQueryable<Order> ReadQuery => Context.Set<Order>().Include(e => e.User).Include(e => e.OrderItems).ThenInclude(e => e.Product);
}

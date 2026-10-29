using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class CartRepository(ShopBdContext context) : Repository<Cart>(context, "CartId"), ICartRepository
{
    protected override IQueryable<Cart> ReadQuery => Context.Set<Cart>().Include(e => e.User).Include(e => e.CartItems).ThenInclude(e => e.Product);
}

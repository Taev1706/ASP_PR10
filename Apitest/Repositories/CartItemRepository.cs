using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class CartItemRepository(ShopBdContext context) : Repository<CartItem>(context, "CartItemId"), ICartItemRepository
{
    protected override IQueryable<CartItem> ReadQuery => Context.Set<CartItem>().Include(e => e.Cart).Include(e => e.Product);
}

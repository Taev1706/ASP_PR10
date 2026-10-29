using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class ProductRepository(ShopBdContext context) : Repository<Product>(context, "ProductId"), IProductRepository
{
    protected override IQueryable<Product> ReadQuery => Context.Set<Product>().Include(e => e.Category);
}

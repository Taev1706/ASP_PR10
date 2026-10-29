using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class CategoryRepository(ShopBdContext context) : Repository<Category>(context, "CategoryId"), ICategoryRepository
{
    protected override IQueryable<Category> ReadQuery => Context.Set<Category>().Include(e => e.Products);
}

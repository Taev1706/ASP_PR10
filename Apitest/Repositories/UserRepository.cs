using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class UserRepository(ShopBdContext context) : Repository<User>(context, "UserId"), IUserRepository
{
    protected override IQueryable<User> ReadQuery => Context.Set<User>().Include(e => e.Role).Include(e => e.Cart).Include(e => e.Orders);
}

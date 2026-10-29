using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class RoleRepository(ShopBdContext context) : Repository<Role>(context, "RoleId"), IRoleRepository
{
    protected override IQueryable<Role> ReadQuery => Context.Set<Role>().Include(e => e.Users);
}

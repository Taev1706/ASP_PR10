using Apitest.Models;
using Microsoft.EntityFrameworkCore;

namespace Apitest.Repositories;

public class ProductReservationRepository(ShopBdContext context) : Repository<ProductReservation>(context, "ProductReservationId"), IProductReservationRepository
{
    protected override IQueryable<ProductReservation> ReadQuery => Context.Set<ProductReservation>().Include(e => e.Product).Include(e => e.User);
}

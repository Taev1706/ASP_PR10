using Apitest.Dtos;

namespace Apitest.Services;

public interface IProductReservationService : IService<ProductReservationDto, CreateProductReservationDto,
    UpdateProductReservationDto, PatchProductReservationDto>
{
    Task CancelAsync(int id, CancellationToken ct);
}

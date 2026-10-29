using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class ProductReservationService(IProductReservationRepository repository, IProductRepository products,
    IUserRepository users, IMapper mapper)
    : Service<ProductReservation, ProductReservationDto, CreateProductReservationDto,
        UpdateProductReservationDto, PatchProductReservationDto>(repository, mapper), IProductReservationService
{
    protected override int GetId(ProductReservation entity) => entity.ProductReservationId;

    public override async Task<ProductReservationDto> CreateAsync(CreateProductReservationDto dto, CancellationToken ct)
    {
        if (dto.Quantity <= 0)
            throw new BusinessRuleException("Количество должно быть больше нуля.");
        var product = await products.GetByIdAsync(dto.ProductId, ct)
            ?? throw new ResourceNotFoundException("Товар не найден.");
        var user = await users.GetByIdAsync(dto.UserId, ct)
            ?? throw new ResourceNotFoundException("Пользователь не найден.");
        if (!user.IsActive)
            throw new BusinessRuleException("Пользователь неактивен.");
        if (product.StockQuantity < dto.Quantity)
            throw new BusinessRuleException($"Недостаточно товара. Доступно: {product.StockQuantity}.");
        var reservation = Mapper.Map<ProductReservation>(dto);
        reservation.CreatedAt = DateTime.UtcNow;
        reservation.Product = product;
        reservation.User = user;
        product.StockQuantity -= dto.Quantity;
        repository.Add(reservation);
        await repository.SaveChangesAsync(ct);
        return Mapper.Map<ProductReservationDto>(reservation);
    }

    public async Task CancelAsync(int id, CancellationToken ct)
    {
        var reservation = await repository.GetByIdAsync(id, ct);
        if (reservation is null || reservation.CancelledAt.HasValue)
            throw new ResourceNotFoundException("Активный резерв не найден.");
        if ((long)reservation.Product.StockQuantity + reservation.Quantity > int.MaxValue)
            throw new BusinessRuleException("Возврат превысит максимальный остаток товара.");
        reservation.Product.StockQuantity += reservation.Quantity;
        reservation.CancelledAt = DateTime.UtcNow;
        await repository.SaveChangesAsync(ct);
    }

    public override Task UpdateAsync(int id, UpdateProductReservationDto dto, CancellationToken ct) =>
        ChangeQuantityAsync(id, dto, dto.Quantity, ct);

    public override Task PatchAsync(int id, PatchProductReservationDto dto, CancellationToken ct) =>
        ChangeQuantityAsync(id, dto, dto.Quantity, ct);

    private async Task ChangeQuantityAsync<TDto>(int id, TDto dto, int? quantity, CancellationToken ct)
    {
        var reservation = await repository.GetByIdAsync(id, ct);
        if (reservation is null || reservation.CancelledAt.HasValue)
            throw new ResourceNotFoundException("Активный резерв не найден.");
        if (!quantity.HasValue) return;
        if (quantity.Value <= 0)
            throw new BusinessRuleException("Количество должно быть больше нуля.");
        var newStock = (long)reservation.Product.StockQuantity + reservation.Quantity - quantity.Value;
        if (newStock < 0)
            throw new BusinessRuleException("Недостаточно товара для увеличения резерва.");
        if (newStock > int.MaxValue)
            throw new BusinessRuleException("Остаток товара превышает допустимое значение.");
        reservation.Product.StockQuantity = (int)newStock;
        Mapper.Map(dto, reservation);
        await repository.SaveChangesAsync(ct);
    }

    protected override Task ValidateDeleteAsync(ProductReservation entity, CancellationToken ct)
    {
        if (!entity.CancelledAt.HasValue)
            throw new DataConflictException("Сначала отмените активный резерв.");
        return Task.CompletedTask;
    }
}

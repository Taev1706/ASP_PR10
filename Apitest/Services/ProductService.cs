using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class ProductService(IProductRepository repository, IMapper mapper,
    ICartItemRepository cartItemRepository,
    ICategoryRepository categoryRepository,
    IOrderItemRepository orderItemRepository,
    IProductReservationRepository productReservationRepository) : Service<Product, ProductDto, CreateProductDto, UpdateProductDto, PatchProductDto>(repository, mapper), IProductService
{
    protected override int GetId(Product entity) => entity.ProductId;

    protected override void Initialize(Product entity) => entity.CreatedAt = DateTime.UtcNow;

    protected override async Task ValidateAsync(Product entity, CancellationToken ct)
    {
        if (!await categoryRepository.AnyAsync(e => e.CategoryId == entity.CategoryId, ct))
            throw new BusinessRuleException("Связанная запись Category не найдена.");
    }

    protected override async Task ValidateDeleteAsync(Product entity, CancellationToken ct)
    {
        if (await orderItemRepository.AnyAsync(e => e.ProductId == entity.ProductId, ct))
            throw new DataConflictException("Сначала удалите связанные записи OrderItem.");
        if (await cartItemRepository.AnyAsync(e => e.ProductId == entity.ProductId, ct))
            throw new DataConflictException("Сначала удалите связанные записи CartItem.");
        if (await productReservationRepository.AnyAsync(e => e.ProductId == entity.ProductId, ct))
            throw new DataConflictException("Сначала удалите связанные записи ProductReservation.");
    }
}

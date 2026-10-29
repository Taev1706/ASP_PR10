namespace Apitest.Dtos;

public class ProductReservationDto
{
    public int ProductReservationId { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public ProductSummaryDto Product { get; set; } = null!;
    public UserSummaryDto User { get; set; } = null!;
}

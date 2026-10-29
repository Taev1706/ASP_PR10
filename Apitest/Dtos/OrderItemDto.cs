namespace Apitest.Dtos;

public class OrderItemDto
{
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public ProductSummaryDto Product { get; set; } = null!;
    public OrderSummaryDto Order { get; set; } = null!;
}

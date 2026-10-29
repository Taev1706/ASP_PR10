namespace Apitest.Dtos;

public class CartItemDto
{
    public int CartItemId { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public ProductSummaryDto Product { get; set; } = null!;
    public CartSummaryDto Cart { get; set; } = null!;
}

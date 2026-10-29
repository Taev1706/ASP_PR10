namespace Apitest.Dtos;

public class ProductSummaryDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
}

namespace Apitest.Dtos;

public class CategoryDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public List<ProductSummaryDto> Products { get; set; } = new();
}

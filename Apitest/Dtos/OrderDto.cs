namespace Apitest.Dtos;

public class OrderDto
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? Status { get; set; }
    public decimal TotalAmount { get; set; }
    public UserSummaryDto User { get; set; } = null!;
    public List<OrderItemDto> OrderItems { get; set; } = new();
}

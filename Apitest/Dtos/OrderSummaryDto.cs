namespace Apitest.Dtos;

public class OrderSummaryDto
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public DateTime? OrderDate { get; set; }
    public string? Status { get; set; }
    public decimal TotalAmount { get; set; }
}

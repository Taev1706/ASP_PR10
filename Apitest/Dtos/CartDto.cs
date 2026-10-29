namespace Apitest.Dtos;

public class CartDto
{
    public int CartId { get; set; }
    public int UserId { get; set; }
    public UserSummaryDto User { get; set; } = null!;
    public List<CartItemDto> CartItems { get; set; } = new();
}

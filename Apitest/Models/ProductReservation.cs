namespace Apitest.Models;

public class ProductReservation
{
    public int ProductReservationId { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public byte[] RowVersion { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public User User { get; set; } = null!;
}

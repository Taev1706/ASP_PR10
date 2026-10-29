namespace Apitest.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public string? ImagePath { get; set; }

    public int StockQuantity { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public virtual ICollection<ProductReservation> Reservations { get; set; } = new List<ProductReservation>();

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}

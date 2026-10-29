using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class CreateProductDto
{
    [Required]
    [StringLength(200, MinimumLength = 1)]
    public string ProductName { get; set; } = null!;

    [Range(typeof(decimal), "0", "99999999.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
    public decimal Price { get; set; }

    [Range(1, int.MaxValue)]
    public int CategoryId { get; set; }

    [StringLength(500, MinimumLength = 0)]
    public string? ImagePath { get; set; }

    [Range(0, int.MaxValue)]
    public int StockQuantity { get; set; }
}

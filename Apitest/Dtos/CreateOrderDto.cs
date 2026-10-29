using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class CreateOrderDto
{
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    [StringLength(20, MinimumLength = 0)]
    public string? Status { get; set; }

    [Range(typeof(decimal), "0", "99999999.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
    public decimal TotalAmount { get; set; }
}

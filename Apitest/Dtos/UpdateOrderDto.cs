using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class UpdateOrderDto
{
    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }

    [JsonRequired]
    public DateTime? OrderDate { get; set; }

    [JsonRequired]
    [StringLength(20, MinimumLength = 0)]
    public string? Status { get; set; }

    [JsonRequired]
    [Range(typeof(decimal), "0", "99999999.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
    public decimal TotalAmount { get; set; }
}

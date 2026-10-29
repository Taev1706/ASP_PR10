using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class UpdateOrderItemDto
{
    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int OrderId { get; set; }

    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }

    [JsonRequired]
    [Range(typeof(decimal), "0", "99999999.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
    public decimal UnitPrice { get; set; }
}

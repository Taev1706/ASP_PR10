using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchOrderItemDto
{
    [Range(1, int.MaxValue)]
    public int? OrderId { get; set; }

    [Range(1, int.MaxValue)]
    public int? ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }

    [Range(typeof(decimal), "0", "99999999.99", ParseLimitsInInvariantCulture = true, ConvertValueInInvariantCulture = true)]
    public decimal? UnitPrice { get; set; }
}

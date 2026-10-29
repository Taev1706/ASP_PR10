using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class UpdateCartItemDto
{
    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int CartId { get; set; }

    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}

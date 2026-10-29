using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchCartItemDto
{
    [Range(1, int.MaxValue)]
    public int? CartId { get; set; }

    [Range(1, int.MaxValue)]
    public int? ProductId { get; set; }

    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }
}

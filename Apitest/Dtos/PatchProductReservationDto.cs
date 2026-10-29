using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchProductReservationDto
{
    
    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }
}

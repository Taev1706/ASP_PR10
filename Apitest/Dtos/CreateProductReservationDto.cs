using System.ComponentModel.DataAnnotations;

namespace Apitest.Dtos;

public class CreateProductReservationDto
{
    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }
    [Range(1, int.MaxValue)]
    public int UserId { get; set; }
    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}

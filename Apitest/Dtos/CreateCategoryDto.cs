using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class CreateCategoryDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string CategoryName { get; set; } = null!;
}

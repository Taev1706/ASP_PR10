using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchCategoryDto
{
    [StringLength(100, MinimumLength = 1)]
    public string? CategoryName { get; set; }
}

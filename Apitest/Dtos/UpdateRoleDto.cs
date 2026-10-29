using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class UpdateRoleDto
{
    [JsonRequired]
    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string RoleName { get; set; } = null!;
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchRoleDto
{
    [StringLength(50, MinimumLength = 1)]
    public string? RoleName { get; set; }
}

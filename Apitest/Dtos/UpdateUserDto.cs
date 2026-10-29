using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class UpdateUserDto
{
    [JsonRequired]
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Login { get; set; } = null!;

    [JsonRequired]
    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string PasswordHash { get; set; } = null!;

    [JsonRequired]
    [Range(1, int.MaxValue)]
    public int RoleId { get; set; }

    [JsonRequired]
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string UserName { get; set; } = null!;

    [JsonRequired]
    public bool IsActive { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class CreateUserDto
{
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string Login { get; set; } = null!;

    [Required]
    [StringLength(256, MinimumLength = 1)]
    public string PasswordHash { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int RoleId { get; set; }

    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string UserName { get; set; } = null!;

    public bool IsActive { get; set; }
}

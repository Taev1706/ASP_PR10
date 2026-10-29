using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Apitest.Dtos;

public class PatchCartDto
{
    [Range(1, int.MaxValue)]
    public int? UserId { get; set; }
}

namespace Apitest.Dtos;

public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = null!;
    public List<UserSummaryDto> Users { get; set; } = new();
}

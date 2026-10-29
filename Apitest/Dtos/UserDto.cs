namespace Apitest.Dtos;

public class UserDto
{
    public int UserId { get; set; }
    public string Login { get; set; } = null!;
    public int RoleId { get; set; }
    public string UserName { get; set; } = null!;
    public bool IsActive { get; set; }
    public RoleSummaryDto Role { get; set; } = null!;
    public CartSummaryDto? Cart { get; set; }
    public List<OrderSummaryDto> Orders { get; set; } = new();
}

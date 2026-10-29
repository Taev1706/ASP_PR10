using Apitest.Dtos;

namespace Apitest.Services;

public interface IRoleService : IService<RoleDto, CreateRoleDto, UpdateRoleDto, PatchRoleDto>
{
}

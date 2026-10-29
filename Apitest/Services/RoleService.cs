using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class RoleService(IRoleRepository repository, IMapper mapper,
    IUserRepository userRepository) : Service<Role, RoleDto, CreateRoleDto, UpdateRoleDto, PatchRoleDto>(repository, mapper), IRoleService
{
    protected override int GetId(Role entity) => entity.RoleId;

    protected override async Task ValidateDeleteAsync(Role entity, CancellationToken ct)
    {
        if (await userRepository.AnyAsync(e => e.RoleId == entity.RoleId, ct))
            throw new DataConflictException("Сначала удалите связанные записи User.");
    }
}

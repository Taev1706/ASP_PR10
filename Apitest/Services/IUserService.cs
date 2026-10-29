using Apitest.Dtos;

namespace Apitest.Services;

public interface IUserService : IService<UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>
{
}

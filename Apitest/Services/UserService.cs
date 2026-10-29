using Apitest.Common;
using AutoMapper;
using Apitest.Dtos;
using Apitest.Models;
using Apitest.Repositories;

namespace Apitest.Services;

public class UserService(IUserRepository repository, IMapper mapper,
    ICartRepository cartRepository,
    IOrderRepository orderRepository,
    IProductReservationRepository productReservationRepository,
    IRoleRepository roleRepository) : Service<User, UserDto, CreateUserDto, UpdateUserDto, PatchUserDto>(repository, mapper), IUserService
{
    protected override int GetId(User entity) => entity.UserId;

    protected override async Task ValidateAsync(User entity, CancellationToken ct)
    {
        if (!await roleRepository.AnyAsync(e => e.RoleId == entity.RoleId, ct))
            throw new BusinessRuleException("Связанная запись Role не найдена.");
        if (await repository.AnyAsync(e => e.Login == entity.Login && e.UserId != entity.UserId, ct))
            throw new DataConflictException("Такой логин уже занят.");
    }

    protected override async Task ValidateDeleteAsync(User entity, CancellationToken ct)
    {
        if (await orderRepository.AnyAsync(e => e.UserId == entity.UserId, ct))
            throw new DataConflictException("Сначала удалите связанные записи Order.");
        if (await cartRepository.AnyAsync(e => e.UserId == entity.UserId, ct))
            throw new DataConflictException("Сначала удалите связанные записи Cart.");
        if (await productReservationRepository.AnyAsync(e => e.UserId == entity.UserId, ct))
            throw new DataConflictException("Сначала удалите связанные записи ProductReservation.");
    }
}

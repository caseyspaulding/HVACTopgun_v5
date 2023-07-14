using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Application.Features.Users;
public interface IUserService
{
    Task CreateUser(UserDto userDto);
    Task DeleteUser(int id);
    Task<UserDto?> GetUserById(int id);
    Task<UserModel> GetUserByObjectId(string objectId);
    Task<int?> GetUserIdByObjectId(string azureObjectId);
    Task UpdateUser(UserDto user);
}
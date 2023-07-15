using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.Services.Features.Users;
public interface IUserService
{
    Task CreateUser(UserDto user);
    Task CreateUserAndTenant();
    Task DeleteUser(int id);
    Task<UserDto?> GetUserById(int id);
    Task<UserModel> GetUserByObjectId(string objectId);
    Task<int?> GetUserIdByObjectId(string azureObjectId);
    Task<UserDto> UpdateUser(UserDto userDto);
    Task<bool> UserExists(string azureAD_ObjectID);
}
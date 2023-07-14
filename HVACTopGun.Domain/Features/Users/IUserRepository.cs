using HVACTopGun.Domain.Features.Users;

namespace HVACTopGun.DataAccess.Features.Users;
public interface IUserRepository
{
    Task CreateUser(UserModel user);
    Task DeleteUser(int id);
    Task<UserModel?> GetUserById(int id);
    Task<UserModel> GetUserByObjectId(string objectId);
    Task<int?> GetUserIdByObjectId(string azureObjectId);
    Task UpdateUser(UserModel user);
}
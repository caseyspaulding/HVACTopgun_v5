using Dapper;
using HVACTopGun.DataAccess.DataAccess;
using HVACTopGun.Domain.Features.Roles;


namespace HVACTopGun.DataAccess.Features.Roles;

public class RoleRepository : IRoleRepository
{
    private readonly ISqlDataAccess _dataAccess;

    public RoleRepository(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<RolesModel>> GetRolesByNames(IEnumerable<string> roleNames)
    {
        var roles = new List<RolesModel>();

        foreach (var roleName in roleNames)
        {
            var parameters = new { RoleName = roleName };

            var result = await _dataAccess.LoadData<RolesModel, dynamic>("spGetRoleByName", parameters);
            roles.AddRange(result);
        }

        return roles;
    }

    public async Task AssignUserRole(int userId, int roleId)
    {
        var parameters = new DynamicParameters();
        parameters.Add("@UserId", userId);
        parameters.Add("@RoleId", roleId);

        await _dataAccess.SaveData("sp_Add_UserRole", parameters);
    }


}


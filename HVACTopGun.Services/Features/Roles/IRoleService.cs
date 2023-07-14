using HVACTopGun.Domain.Features.Roles;

namespace HVACTopGun.Application.Features.Roles;
public interface IRoleService
{
    Task AssignUserRole(int userId, int roleId);
    Task<IEnumerable<RolesModel>> GetRolesByNames(IEnumerable<string> roleNames);
}
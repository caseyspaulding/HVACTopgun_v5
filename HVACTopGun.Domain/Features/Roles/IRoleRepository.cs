using HVACTopGun.Domain.Features.Roles;

public interface IRoleRepository
{
    Task AssignUserRole(int userId, int roleId);
    Task<IEnumerable<RolesModel>> GetRolesByNames(IEnumerable<string> roleNames);
}
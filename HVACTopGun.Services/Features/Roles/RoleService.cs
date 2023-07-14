using HVACTopGun.Domain.Features.Roles;

namespace HVACTopGun.Application.Features.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public Task<IEnumerable<RolesModel>> GetRolesByNames(IEnumerable<string> roleNames)
        {
            return _roleRepository.GetRolesByNames(roleNames);
        }

        public Task AssignUserRole(int userId, int roleId)
        {
            return _roleRepository.AssignUserRole(userId, roleId);
        }
    }
}
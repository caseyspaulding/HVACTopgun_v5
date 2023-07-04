using DataAccess.Models;

namespace DataAccess.DataService
{
    public interface IRoleDataService
    {
        Task AssignUserRole(int userId, int roleId);
        Task<IEnumerable<RolesModel>> GetRolesByNames(IEnumerable<string> roleNames);
    }
}
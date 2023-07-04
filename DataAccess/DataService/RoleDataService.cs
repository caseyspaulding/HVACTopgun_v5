using DataAccess.DbAccess;

namespace DataAccess.DataService
{
    public class RoleDataService : IRoleDataService
    {
        private readonly ISqlDataAccess _dataAccess;

        public RoleDataService(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public async Task AddUserRole(int userId, int roleId)
        {
            var parameters = new { UserId = userId, RoleId = roleId };
            await _dataAccess.SaveData("sp_Add_UserRole", parameters);
        }



    }
}

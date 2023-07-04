namespace DataAccess.DataService
{
    public interface IRoleDataService
    {
        Task AddUserRole(int userId, int roleId);
    }
}
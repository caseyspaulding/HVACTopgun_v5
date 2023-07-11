namespace DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<int> InsertDataReturnId<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
    }
}
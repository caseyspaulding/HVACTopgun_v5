using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    // IConfiguration gets your settings from secrets, key vault, app settings, etc.
    public SqlDataAccess(IConfiguration config)
    {
        this._config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "DefaultConnection")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(storedProcedure, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection")
    {
        try
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            // Log the exception using your preferred logging framework (e.g., Serilog, NLog, etc.)
            // Example using Console.WriteLine:
            Console.WriteLine($"Error executing stored procedure '{storedProcedure}': {ex.Message}");

            // You can choose to rethrow the exception or handle it as necessary based on your application's requirements.
            throw;
        }
    }
    public async Task<int> InsertDataReturnId<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection")
    {
        try
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.ExecuteScalarAsync<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error executing stored procedure '{storedProcedure}': {ex.Message}");
            throw;
        }
    }
}
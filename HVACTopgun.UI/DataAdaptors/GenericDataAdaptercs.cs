using DataAccess.DbAccess;
using Syncfusion.Blazor;

public class GenericDataAdapter<T> : DataAdaptor where T : class
{
    private readonly ISqlDataAccess _dataAccess;

    public GenericDataAdapter(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
    {
        var items = await _dataAccess.LoadData<T, dynamic>($"spGetAll{typeof(T).Name}s", new { });

        return items;
    }

    public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
    {
        var item = data as T;

        await _dataAccess.SaveData($"spAdd{typeof(T).Name}", item);

        return data;
    }

    public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
    {
        var item = data as T;

        await _dataAccess.SaveData($"spUpdate{typeof(T).Name}", item);

        return data;
    }

    public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
    {
        await _dataAccess.SaveData($"spDelete{typeof(T).Name}", new { Id = primaryKeyValue });

        return primaryKeyValue;
    }
}

using DataAccess.DbAccess;
using Syncfusion.Blazor;

//namespace HVACTopGun.UI.Data.DataAdaptors
//{
//using DataAccess.DbAccess;
//using Syncfusion.Blazor.Data;
//using Syncfusion.Blazor;

//public class EmployeeDataAdapter : DataAdaptor
//{
//    private readonly ISqlDataAccess _dataAccess;

//    public EmployeeDataAdapter(ISqlDataAccess dataAccess)
//    {
//        _dataAccess = dataAccess;
//    }

//    public override async Task<object> ExecuteSelect(DataManagerRequest dm, string key = null)
//    {
//        IEnumerable<Employee> employees = await _dataAccess.LoadData<Employee, dynamic>("GetAllEmployees", new { });
//        DataResult result = new DataResult();
//        result.result = employees;
//        result.count = employees.Count();
//        return result;
//    }

//    public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
//    {
//        var employee = data as Employee;
//        await _dataAccess.SaveData("InsertEmployee", employee);
//        var crudResult = new CrudResult();
//        crudResult.action = "insert";
//        crudResult.result = employee;
//        return crudResult;
//    }

//    public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
//    {
//        var employee = data as Employee;
//        await _dataAccess.SaveData("UpdateEmployee", employee);
//        var crudResult = new CrudResult();
//        crudResult.action = "update";
//        crudResult.result = employee;
//        return crudResult;
//    }

//    public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
//    {
//        var employeeId = (int)primaryKeyValue;
//        await _dataAccess.SaveData("DeleteEmployee", new { EmployeeId = employeeId });
//        var crudResult = new CrudResult();
//        crudResult.action = "remove";
//        crudResult.key = primaryKeyValue;
//        return crudResult;
//    }
//}
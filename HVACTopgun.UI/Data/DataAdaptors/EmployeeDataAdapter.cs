//using DataAccess.DbAccess;
//using Syncfusion.Blazor;

//namespace HVACTopGun.UI.Data.DataAdaptors
//{
//    public class EmployeeDataAdapter : DataAdaptor
//    {
//        private readonly ISqlDataAccess _dataAccess;

//        public EmployeeDataAdapter(ISqlDataAccess dataAccess)
//        {
//            _dataAccess = dataAccess;
//        }

//        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
//        {
//            // Implement the ReadAsync method to retrieve data from the Employee table
//            // using the data access layer and return it in a format compatible with Syncfusion components.
//            // You can use Dapper or any other methods provided by your data access layer.
//            var employees = await _dataAccess.LoadData<Employee>("GetAllEmployees");

//            return employees;
//        }

//        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
//        {
//            // Implement the InsertAsync method to insert new employee data into the Employee table
//            // using the data access layer. Extract the relevant information from the 'data' parameter.
//            var employee = data as Employee;

//            // Call the appropriate method from the data access layer to perform the insertion.
//            await _dataAccess.SaveData<Employee>("InsertEmployee", employee);

//            // Optionally, you can return the inserted data or perform additional operations as needed.
//            return data;
//        }

//        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
//        {
//            // Implement the UpdateAsync method to update employee data in the Employee table
//            // using the data access layer. Extract the relevant information from the 'data' parameter.
//            var employee = data as Employee;

//            // Call the appropriate method from the data access layer to perform the update.
//            await _dataAccess.SaveData<Employee>("UpdateEmployee", employee);

//            // Optionally, you can return the updated data or perform additional operations as needed.
//            return data;
//        }

//        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
//        {
//            // Implement the RemoveAsync method to delete employee data from the Employee table
//            // using the data access layer. Extract the relevant information from the 'primaryKeyValue' parameter.
//            var employeeId = (int)primaryKeyValue;

//            // Call the appropriate method from the data access layer to perform the deletion.
//            await _dataAccess.DeleteData<Employee>("DeleteEmployee", new { EmployeeId = employeeId });

//            // Optionally, you can return the deleted primary key value or perform additional operations as needed.
//            return primaryKeyValue;
//        }
//    }
//}

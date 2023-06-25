using DataAccess.DbAccess;
using DataAccess.Models;
using DataAccess.Models.Interfaces;

namespace DataAccess.Data;

public class CustomerSqlDataService : ICustomerDataService
{
    private readonly ISqlDataAccess _dataAccess;

    public CustomerSqlDataService(ISqlDataAccess dataAccess)
    {
        this._dataAccess = dataAccess;
    }

    public Task<IEnumerable<CustomerModel>> GetAllCustomers()
    {
        return _dataAccess.LoadData<CustomerModel, dynamic>("dbo.getAllCustomers", new { });
    }

    public async Task<CustomerModel?> GetCustomer(int id)
    {
        var results = await _dataAccess.LoadData<CustomerModel, dynamic>(
            "dbo.getCustomer",
            new { Id = id });
        return results.FirstOrDefault();
    }

    // insert, update, delete
    public Task CreateCustomer(ICustomerModel customer) => _dataAccess.SaveData("dbo.addCustomer",
        new { customer.FirstName, customer.LastName });

    public Task UpdateCustomer(CustomerModel customer) =>
        _dataAccess.SaveData("dbo.updateCustomer", customer);

    public Task DeleteCustomer(int id) =>
        _dataAccess.SaveData("dbo.deleteCustomer", new { Id = id });

    public Task CreateCustomer(CustomerModel customer)
    {
        throw new NotImplementedException();
    }
}
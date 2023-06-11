using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class CustomerData : ICustomerData
{
    private readonly ISqlDataAccess _db;

    public CustomerData(ISqlDataAccess db)
    {
        this._db = db;
    }

    public Task<IEnumerable<CustomerModel>> GetAllCustomers()
    {
        return _db.LoadData<CustomerModel, dynamic>("dbo.getAllCustomers", new { });
    }

    public async Task<CustomerModel?> GetCustomer(int id)
    {
        var results = await _db.LoadData<CustomerModel, dynamic>(
            "dbo.getCustomer",
            new { Id = id });
        return results.FirstOrDefault();
    }

    // insert, update, delete
    public Task AddCustomer(CustomerModel customer) => _db.SaveData("dbo.addCustomer",
        new { customer.FirstName, customer.LastName });

    public Task UpdateCustomer(CustomerModel customer) =>
        _db.SaveData("dbo.updateCustomer", customer);

    public Task DeleteCustomer(int id) =>
        _db.SaveData("dbo.deleteCustomer", new { Id = id });
}
using DataAccess.Models;

namespace DataAccess.Data
{
    public interface ICustomerDataService
    {
        Task CreateCustomer(ICustomerModel customer);

        Task DeleteCustomer(int id);

        Task<IEnumerable<CustomerModel>> GetAllCustomers();

        Task<CustomerModel?> GetCustomer(int id);

        Task UpdateCustomer(CustomerModel customer);
    }
}
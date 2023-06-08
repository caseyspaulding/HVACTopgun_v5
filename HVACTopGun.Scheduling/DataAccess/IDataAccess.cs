using HVACTopGun.Scheduling.Models;

namespace HVACTopGun.Scheduling.DataAccess
{
    public interface IDataAccess
    {
        List<CustomerModel> GetCustomers();
        CustomerModel InsertPerson(string firstName, string lastName);
    }
}
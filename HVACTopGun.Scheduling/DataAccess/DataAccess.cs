using HVACTopGun.Scheduling.Models;

namespace HVACTopGun.Scheduling.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<CustomerModel> customers = new();

        public DataAccess()
        {
            customers.Add(new CustomerModel { Id = 1, FirstName = "Casey", LastName = "Spaulding" });
            customers.Add(new CustomerModel { Id = 2, FirstName = "James", LastName = "Kirk" });
        }

        public List<CustomerModel> GetCustomers()
        {
            return customers;
        }

        public CustomerModel InsertPerson(string firstName, string lastName)
        {
            CustomerModel customer = new CustomerModel { FirstName = firstName, LastName = lastName };
            customer.Id = customers.Max(x => x.Id) + 1;
            customers.Add(customer);
            return customer;
        }
    }
}

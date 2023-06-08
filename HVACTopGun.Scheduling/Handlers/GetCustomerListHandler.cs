using HVACTopGun.Scheduling.DataAccess;
using HVACTopGun.Scheduling.Models;
using HVACTopGun.Scheduling.Queries;
using MediatR;

namespace HVACTopGun.Scheduling.Handlers
{
    // the first argument is what you are going to handle. In this example it is the
    // GetCustomerListQuery and the return is the List<Customer>
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<CustomerModel>>
    {
        private readonly IDataAccess _data;
        public GetCustomerListHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<List<CustomerModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetCustomers());
        }
    }
}

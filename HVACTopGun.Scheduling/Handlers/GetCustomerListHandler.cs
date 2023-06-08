using HVACTopGun.Scheduling.Models;
using HVACTopGun.Scheduling.Queries;
using MediatR;

namespace HVACTopGun.Scheduling.Handlers
{
    //the first argument is what you are going to handle. In this example it is the       GetCustomerListQuery and the return is the List<Customer>
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<CustomerModel>>
    {
        public GetCustomerListHandler()
        {

        }

        public Task<List<CustomerModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

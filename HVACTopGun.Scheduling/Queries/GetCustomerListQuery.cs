using HVACTopGun.Scheduling.Models;
using MediatR;


namespace HVACTopGun.Scheduling.Queries
{
    // Every Query has only one handler

    // IRequest is what is being returned 
    public record GetCustomerListQuery() : IRequest<List<CustomerModel>>;

}

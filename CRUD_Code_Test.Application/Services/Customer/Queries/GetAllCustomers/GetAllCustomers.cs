using CRUD_Code_Test.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Application.Services.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomers : IRequest<IEnumerable<CRUD_Code_Test.Domain.Entities.Customer>>
    {
        public class GetAllCustomersHandler : IRequestHandler<GetAllCustomers, IEnumerable<CRUD_Code_Test.Domain.Entities.Customer>>
        {
            private readonly ICustomerContext _context;
            public GetAllCustomersHandler(ICustomerContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<CRUD_Code_Test.Domain.Entities.Customer>> Handle(GetAllCustomers query, CancellationToken cancellationToken)
            {
                var CustomerList = await _context.customers.ToListAsync();
                if (CustomerList == null)
                {
                    return null;
                }
                return CustomerList.AsReadOnly();
            }
        }
    }
}

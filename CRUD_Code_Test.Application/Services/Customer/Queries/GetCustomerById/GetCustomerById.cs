using CRUD_Code_Test.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Application.Services.Customer.Queries.GetCustomerById
{
    public class GetCustomerById: IRequest<CRUD_Code_Test.Domain.Entities.Customer>
    {
        public int Id { get; set; }
        public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerById, CRUD_Code_Test.Domain.Entities.Customer>
        {
            private readonly ICustomerContext _context;
            public GetCustomerByIdQueryHandler(ICustomerContext context)
            {
                _context = context;
            }
            public async Task<CRUD_Code_Test.Domain.Entities.Customer> Handle(GetCustomerById query, CancellationToken cancellationToken)
            {
                var customer = _context.customers.Where(a => a.Id == query.Id).FirstOrDefault();
                if (customer == null) return null;
                return customer;
            }
        }
    }
}

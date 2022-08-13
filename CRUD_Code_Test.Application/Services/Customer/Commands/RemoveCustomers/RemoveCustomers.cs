using CRUD_Code_Test.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Application.Services.Customer.Commands.RemoveCustomers
{
    public class RemoveCustomers : IRequest<int>
    {
        public int Id { get; set; }
        public class RemoveCustomersCommandHandler : IRequestHandler<RemoveCustomers, int>
        {
            private readonly ICustomerContext _context;
            public RemoveCustomersCommandHandler(ICustomerContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(RemoveCustomers command, CancellationToken cancellationToken)
            {
                var customer = await _context.customers.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (customer == null) return default;
                _context.customers.Remove(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}

using CRUD_Code_Test.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Application.Services.Customer.Commands.RegisterCustomers
{
    public class RegisterCustomers:IRequest<int>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public class RegisterCustomersCommandHandler : IRequestHandler<RegisterCustomers, int>
        {
            private readonly ICustomerContext _context;
            public RegisterCustomersCommandHandler(ICustomerContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(RegisterCustomers command, CancellationToken cancellationToken)
            {
                var customer = new CRUD_Code_Test.Domain.Entities.Customer()
                {
                    Firstname = command.Firstname,
                    Lastname = command.Lastname,
                    DateOfBirth = command.DateOfBirth,
                    PhoneNumber = command.PhoneNumber,
                    Email = command.Email,
                    BankAccountNumber = command.BankAccountNumber
                };
                _context.customers.Add(customer);
                await _context.SaveChanges();
                return customer.Id;
            }
        }
    }
}

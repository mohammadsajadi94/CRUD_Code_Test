using CRUD_Code_Test.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Application.Services.Customer.Commands.EditCustomers
{
    public class EditCustomers : IRequest<int>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
        public class EditCustomersCommandHandler : IRequestHandler<EditCustomers, int>
        {
            private readonly ICustomerContext _context;
            public EditCustomersCommandHandler(ICustomerContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(EditCustomers command, CancellationToken cancellationToken)
            {
                var customer = _context.customers.Where(a => a.Id == command.Id).FirstOrDefault();
                if (customer == null)
                {
                    return default;
                }
                else
                {
                    customer.Firstname = command.Firstname;
                    customer.Lastname = command.Lastname;
                    customer.DateOfBirth = command.DateOfBirth;
                    customer.PhoneNumber = command.PhoneNumber;
                    customer.Email = command.Email;
                    customer.BankAccountNumber = command.BankAccountNumber;
                    await _context.SaveChanges();
                    return customer.Id;
                }
            }
        }
    }
}

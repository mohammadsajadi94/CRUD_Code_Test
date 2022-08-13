using CRUD_Code_Test.Application.Services.Customer.Commands.EditCustomers;
using CRUD_Code_Test.Application.Services.Customer.Commands.RegisterCustomers;
using CRUD_Code_Test.Application.Services.Customer.Commands.RemoveCustomers;
using CRUD_Code_Test.Application.Services.Customer.Queries.GetAllCustomers;
using CRUD_Code_Test.Application.Services.Customer.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpPost]
        public async Task<IActionResult> Create(RegisterCustomers command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCustomers()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerById { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new RemoveCustomers { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EditCustomers command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}

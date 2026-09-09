using Customer.Api.Models;
using Customer.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService customerService;

        public CustomersController(CustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await customerService.GetById(id);

            return Ok(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerRequest request)
        {
            var customer = new Entities.Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            var createdCustomer = await customerService.Create(customer);

            return Created($"/customers/{createdCustomer.Id}", createdCustomer);
        }
    }
}

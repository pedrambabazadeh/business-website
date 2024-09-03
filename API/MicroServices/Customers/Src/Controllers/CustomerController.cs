using API.MicroServices.Customers.Interfaces;
using API.MicroServices.Customers.Mappers;
using API.MicroServices.Customers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.MicroServices.Customers.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerRepo;

        public CustomerController(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CustomerQuery query)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var customers = await customerRepo.GetAllAsync(query);
            var customerDto = customers.Select(c => c.ToCustomerDto()).ToList();

            return Ok(customerDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var customerDto = await customerRepo.GetById(id);
            
            return customerDto is null ? NotFound("Customer not found") : Ok(customerDto);
        }
    }
}
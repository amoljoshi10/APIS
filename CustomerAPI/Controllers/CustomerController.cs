using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CustomerAPI.Interfaces; 

namespace CustomerAPI.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {

        //private readonly ILogger<CustomerController> _logger;

        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        //public CustomerController(ILogger<CustomerController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet()]
        public IEnumerable<Customer> Get()
        {

            return _customerService.GetCustomers();
        }
        [HttpGet("{customerId}")]
        public IActionResult GetById(int customerId)
        {

            var customer=_customerService.GetCustomerById(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);

        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _customerService.AddCustomer(customer);

            return Created("customer/{customer.CustomerID}", customer);
        }

        [HttpPut("{customerId}")]
        public IActionResult UpdateCustomer(int customerId, [FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customerEntity = _customerService.GetCustomerById(customerId);
            if (customerEntity == null)
            {
                return NotFound();
            }
            
            _customerService.UpdateCustomer(customerEntity, customer);

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public IActionResult DeleteCustomer(int customerId)
        {
            var customerEntity = _customerService.GetCustomerById(customerId);
            if (customerEntity == null)
            {
                return NotFound();
            }
            _customerService.DeletCustomer(customerEntity);
            return Ok(true);
        }

        }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeCorp.API.Models;
using AcmeCorp.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AcmeCorp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }


        [Route("AddUpdateCustomer")]
        [HttpPost]
        public IActionResult AddUpdateCustomer(Customers customer)
        {
            try
            {
                Response res = _customerRepository.AddUpdateCustomer(customer);
                return Ok(res);

            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("DeleteCustomer")]
        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                Response res = _customerRepository.DeleteCustomer(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [Route("GetCustomer")]
        [HttpGet]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                Customers customer = _customerRepository.GetCustomer(id);
                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [Route("GetAllCustomers")]
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                List<Customers> customerList = _customerRepository.GetCustomers();
                return Ok(customerList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}

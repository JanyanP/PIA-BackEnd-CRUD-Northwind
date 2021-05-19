using DatabaseFirstDWB.BackEnd;
using DatabaseFirstDWB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public List<CustomerModel> Get()
        {
            var customers = new CustomerSC().GetAllCustomers().Select(s => new CustomerModel
            {
                idString = s.CustomerId,
                name = s.CompanyName,
                cityName = s.City,
                phoneNumber = s.Phone
            }).ToList();

            return customers;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerModel Get(string id)
        {
            var customer = new CustomerSC().GetCustomerById(id);
            var customerModel = new CustomerModel();
            try 
            {
                customerModel.idString = customer.CustomerId;
                customerModel.name = customer.CompanyName;
                customerModel.cityName = customer.City;
                customerModel.phoneNumber = customer.Phone;
            }
            catch
            {
                customerModel.idString = "";
                customerModel.name = "";
                customerModel.cityName = "";
                customerModel.phoneNumber = "";
            }

            return customerModel;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] CustomerModel newCustomer)
        {
            new CustomerSC().AddCustomer(newCustomer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CustomerModel customer)
        {
            new CustomerSC().UpdateCustomer(id, customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            new CustomerSC().RemoveCustomer(id);
        }
    }
}

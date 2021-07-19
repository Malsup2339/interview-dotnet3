using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repositories;

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private static ICustomerDA _repository;

        public CustomersController()
        {
            _repository = new CustomerDA();
        }

        [HttpGet]
        public async Task<CustomerCollection> GetCustomersAsync()
        {
            var response = await _repository.GetCustomersAsync();

            return response.Customers;            
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            var response = await _repository.GetCustomerByIdAsync(id);

            return response.Customer;
        }

        [HttpPost("Add/{name}")]
        public async Task<bool> AddCustomer(string name)
        {
            var response = await _repository.AddCustomerAsync(name);

            return response.Success;
        }

        [HttpPost("Update/{id}/{name}")]
        public async Task<bool> UpdateCustomer(int id, string name)
        {
            var response = await _repository.UpdateCustomerAsync(id, name);

            return response.Success;
        }
    }
}

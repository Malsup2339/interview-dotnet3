using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace GroceryStoreAPI.Repositories
{
    public class CustomerDA : ICustomerDA
    {
        private readonly string DATABASE_NAME = "E:\\Desktop\\Autobooks_Code_Assessment\\interview-dotnet3\\GroceryStoreAPI\\database.json";

        public CustomerDA()
        {
           
        }

        public async Task<AddCustomerResponse> AddCustomerAsync(string name)
        {
            var response = new AddCustomerResponse();

            try
            {
                if (IsNameValid(name))
                {
                    var customers = await GetCustomers();

                    var newCustomer = new Customer();

                    if (customers.Customers.Count == 0)
                    {
                        newCustomer.Id = 1;
                    }
                    else
                    {
                        newCustomer.Id = customers.Customers.Max(x => x.Id) + 1;
                    }

                    newCustomer.Name = name;

                    customers.Customers.Add(newCustomer);

                    UpdateCustomerDatabase(customers);

                    response.Success = true;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Name is invalid.";
                }
               
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to add customer. " + ex.Message;
            }

            return response;
            
        }

        public async Task<GetCustomerByIdResponse> GetCustomerByIdAsync(int id)
        {
            var response = new GetCustomerByIdResponse();
            var customers = await GetCustomers();

            var result = customers.Customers.FirstOrDefault(x => x.Id == id);

            if(result != null)
            {
                response.Customer = result;
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "No customer found";
            }

            return response;
        }        

        public async Task<GetCustomersResponse> GetCustomersAsync()
        {
            var response = new GetCustomersResponse();

            try
            {
                response.Customers = await GetCustomers();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Failed to retrieve customers. " + ex.Message;
            }            

            return response;
        }

        public async Task<UpdateCustomerResponse> UpdateCustomerAsync(int customerIdToUpdate, string name)
        {
            var response = new UpdateCustomerResponse();

            try
            {
                if (IsNameValid(name))
                {
                    var customers = await GetCustomers();

                    var target = customers.Customers.FirstOrDefault(x => x.Id == customerIdToUpdate);

                    if (target != null)
                    {
                        target.Name = name;

                        UpdateCustomerDatabase(customers);

                        response.Success = true;
                    }
                    else
                    {
                        response.Success = false;
                        response.Message = "Could not find customer";
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "Name is invalid.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error occurred while updating customer info. " + ex.Message;
            }
                  

            return response;
        }

        private async Task<CustomerCollection> GetCustomers()
        {
            using (var stream = File.OpenRead(DATABASE_NAME))
            {
                var customers = await JsonSerializer.DeserializeAsync<CustomerCollection>(stream);

                return customers;
            }
        }

        private async void UpdateCustomerDatabase(CustomerCollection customers)
        {
            using (var stream = File.Open(DATABASE_NAME, FileMode.Truncate))
            {
                await JsonSerializer.SerializeAsync<CustomerCollection>(stream, customers);
            }            
        }

        private bool IsNameValid(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z]+$");
        }
    }
}

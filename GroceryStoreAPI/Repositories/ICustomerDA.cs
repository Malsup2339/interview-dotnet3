using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Models;

namespace GroceryStoreAPI.Repositories
{
    public interface ICustomerDA
    {
        Task<GetCustomersResponse> GetCustomersAsync();

        Task<GetCustomerByIdResponse> GetCustomerByIdAsync(int id);

        Task<AddCustomerResponse> AddCustomerAsync(string name);

        Task<UpdateCustomerResponse> UpdateCustomerAsync(int customerIdToUpdate, string name);
    }
}

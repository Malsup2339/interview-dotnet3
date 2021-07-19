using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class CustomerCollection
    {
        public List<Customer> Customers { get; set; }

        public CustomerCollection()
        {
            Customers = new List<Customer>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class GetCustomersResponse : Response
    {
        public CustomerCollection Customers { get; set; }

        public GetCustomersResponse()
        {
            Customers = new CustomerCollection();
        }
    }
}

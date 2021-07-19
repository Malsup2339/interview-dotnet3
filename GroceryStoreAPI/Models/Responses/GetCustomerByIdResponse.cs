using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public class GetCustomerByIdResponse : Response
    {
        public Customer Customer { get; set; }

        public GetCustomerByIdResponse()
        {
            Customer = new Customer();
        }
    }
}

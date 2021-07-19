using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Models
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InventoryManagement.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long PhoneNumber { get; set; }
        public int Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}

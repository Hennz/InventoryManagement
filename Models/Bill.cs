using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Bill
    {
        public int BillId { get; set; }       
        public DateTime BillDate { get; set; }
        public float Discount { get; set; }
        public int PaymentMode { get; set; }
        public float Total { get; set; }
        public int Status{ get; set; }

        //public int UserId { get; set; }//as foreign key
        //public int CustomerId { get; set; }//as foreign key

    }
}

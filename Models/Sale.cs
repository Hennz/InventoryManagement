using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int BillId { get; set; }
        public string ItemName { get; set; }
        public int QuantitySold { get; set; }
        public string Unit { get; set; }
        public DateTime Date { get; set; }
    }
}

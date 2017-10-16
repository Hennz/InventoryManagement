using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Dtos
{
    public class BillItemDto
    {
        public string Barcode { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }
        //Unit for measurement of the item 
        public string Unit { get; set; }
        //Wholesale price
        public float Rate { get; set; }

        public string Discount { get; set; }

        public float Total { get; set; }
    }
}

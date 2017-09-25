using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //Unit for measurement of the item 
        public string Unit { get; set; }
        public int Stock { get; set; }
        public float SellingPrice { get; set; }
        public float WholeSalePrice { get; set; }
        //Status to check availability
        public int Status { get; set; }
        public string Barcode { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }





        //Category id as foreign key

    }
}

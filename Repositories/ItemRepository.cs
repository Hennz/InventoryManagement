using InventoryManagement.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Context;
using InventoryManagement.Models;

namespace InventoryManagement.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Item GetItemByBarcodeNumber(InventoryDBContext inventoryDBContext, string barcode)
        {
            return inventoryDBContext.Items.Where(x => x.Barcode == barcode).FirstOrDefault();
        }
    }
}

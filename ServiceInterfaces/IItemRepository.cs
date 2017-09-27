using InventoryManagement.Context;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.ServiceInterfaces
{
    public interface IItemRepository
    {
        Item GetItemByBarcodeNumber(InventoryDBContext inventoryDBContext, string barcode);
        
    }
}

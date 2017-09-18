using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Flags
{
    public class Flags
    {
        public enum GenderType
        {
            Male=1,
            Female=0
        }
        public enum ItemStatusType
        {
            Available=1,
            NotAvailable=0
        }
        public enum PaymentModeType
        {
            Cash,
            NetBanking,
            PayTM,
            CardSwipe,
            Bhim,
        }
        public enum BillStatusType
        {
            Paid=1,
            Unpaid=0,
            PartiallyPaid=2
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Sales
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }

        public string CarrierTrackingNumber { get; set; }

        public short OrderQty { get; set; }
        public int ProductID { get; set; }
        public int SpecialOfferID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }

    }
}

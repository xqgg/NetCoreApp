using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ViewModel.Respons
{
    public class SalesCalculationRespons
    {
        public int SalesOrderID { get; set; }
        public int OrderQty { get; set; }

        public decimal LineTotal { get; set; }


    }
}

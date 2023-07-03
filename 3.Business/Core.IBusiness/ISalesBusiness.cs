using Core.IBusiness.Base;
using Core.Models;
using Core.ViewModel.Respons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.IBusiness
{
    public interface ISalesBusiness : IBaseBusiness<SalesOrderDetail>
    {
        public Task<bool> AddMillion();


        public Task<IEnumerable<SalesCalculationRespons>> GetSalesCalculation();
    }
}

using ColinChang.RedisHelper;
using Core.Common.Filter;
using Core.Common.Jwt;
using Core.IBusiness;
using Core.Models;
using Core.ViewModel.Request;
using Core.ViewModel.Respons;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{

    public class SalesController : ControllerBase
    {
        private readonly ISalesBusiness _salesBusiness;

        public SalesController(ISalesBusiness salesBusiness)
        {
            _salesBusiness = salesBusiness;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<bool> AddMillion()
        {
            return await _salesBusiness.AddMillion();
        }


        [HttpGet]
        public async Task<IEnumerable<SalesCalculationRespons>> GetSales()
        {
            return await _salesBusiness.GetSalesCalculation();
        }

    }
}

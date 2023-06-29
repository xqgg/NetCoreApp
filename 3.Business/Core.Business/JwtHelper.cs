using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Core.Business
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        public JwtHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }





        //public string GetJwt()
        //{
        //    _configuration.GetSection("");

        //    List<Claim> claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, "jwt")
        //    };


        //}

    }
}
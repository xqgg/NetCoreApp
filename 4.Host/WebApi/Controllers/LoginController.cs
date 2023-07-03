using ColinChang.RedisHelper;
using Core.Common.Filter;
using Core.Common.Jwt;
using Core.IBusiness;
using Core.Models;
using Core.ViewModel.Request;
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

    public class LoginController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IConfiguration _configuration;
        private readonly IRedisHelper _redis;

        public LoginController(IUserBusiness userBusiness, IConfiguration configuration, IRedisHelper redis)
        {
            _userBusiness = userBusiness;
            _configuration = configuration;
            _redis = redis;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ResultModel> GetToken(LoginRequest model)
        {

            ResultModel resultModel = new ResultModel() { Code = ResultCode.SUCCESS, Info = "成功" };

            try
            {
                Authority_User user = await _userBusiness.Login(model.Account, model.Password);
                List<string> roleCodes = await _userBusiness.GetUserRoles(user.ID);
                JwtOptions jwtInfo = _configuration.GetSection("JwtInfo").Get<JwtOptions>();
                IEnumerable<Claim> claims = new List<Claim>() {
                new Claim(JwtClaimTypes.Id,user.ID.ToString()),
                new Claim(JwtClaimTypes.Name,model.Account),
                new Claim(JwtClaimTypes.Role,string.Join(',',roleCodes)),
                new Claim(JwtRegisteredClaimNames.Sub, model.Account),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.Now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

                //notBefore  生效时间
                // long nbf =new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
                var nbf = DateTime.UtcNow;
                //expires   //过期时间
                // long Exp = new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds();
                var Exp = DateTime.UtcNow.AddMinutes(30);
                //signingCredentials  签名凭证
                var secret = Encoding.UTF8.GetBytes(jwtInfo.SecurityKey);
                var key = new SymmetricSecurityKey(secret);
                var signcreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var jwt = new JwtSecurityToken(issuer: jwtInfo.Issuer, audience: jwtInfo.Audience, claims: claims, notBefore: nbf, expires: Exp, signingCredentials: signcreds);
                var JwtHander = new JwtSecurityTokenHandler();
                resultModel.Data = JwtHander.WriteToken(jwt);
            }
            catch (Exception ex)
            {

                resultModel.Code = ResultCode.FAIL;
                resultModel.Info = ex.Message;
            }


            return resultModel;

        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<string> Get()
        {
            const string key = "msg";
            //await _redis.StringSetAsync(key, "hello world");


            //await _redis.StringSetAsync(key, "");
            //await _redis.KeyExpireAsync(key, TimeSpan.FromSeconds(10));




            //await _redis.StringSetAsync("age", 18);
            //await _redis.StringIncrementAsync("age");


            await _redis.EnqueueAsync(key, DateTime.Now);
            await _redis.EnqueueAsync(key, DateTime.Now.AddSeconds(5));
            await _redis.KeyExpireAsync(key, TimeSpan.FromSeconds(5));






            //var content = await _redis.StringGetAsync<string>(key);
            //await _redis.KeyDeleteAsync(new[] { key });
            return key;
        }

    }
}

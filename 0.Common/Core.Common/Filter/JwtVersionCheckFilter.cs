using ColinChang.RedisHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Filter
{
    public class JwtVersionCheckFilter : IAsyncAuthorizationFilter
    {
        private readonly IRedisHelper redis;

        public JwtVersionCheckFilter(IRedisHelper redis)
        {
            this.redis = redis;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            // 检查当前操作方法是否使用了 [Authorize] 特性
            if (context.ActionDescriptor.EndpointMetadata.Any(m => m is AuthorizeAttribute))
            {
                // 获取 jwtv 声明的值
                string jwtv = context.HttpContext.User.FindFirst("jwtv")?.Value;

                if (!string.IsNullOrEmpty(jwtv))
                {
                    // 获取用户 ID

                    string userId = context.HttpContext.User.FindFirst(IdentityModel.JwtClaimTypes.Id)?.Value;


                    // 从 Redis 中获取存储的 JWT 版本号
                    int? storedJwtVersion = await redis.StringGetAsync<int>("userjv_" + userId);

                    if (storedJwtVersion == null || storedJwtVersion.ToString() != jwtv)
                    {
                        // JWT 版本号无效，拒绝访问
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
            else
            {
                //nothing
            }
        }
    }
}

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Core.Service.Context;
using Core.Common.Modules;
using GC.WebApi.Common.Routes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ColinChang.RedisHelper;
using Core.Common.Filter;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

//builder.Services.AddControllers();


#region EF配置
// 配置 EF 连接字符串
builder.Services.AddDbContext<NCDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("local"));

    //options.UseSqlServer(builder.Configuration.GetConnectionString("cloud"));

});

#endregion





#region 跨域

var corsPolicyName = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: corsPolicyName,
        builder =>
        {
            builder.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

#endregion


#region 注册Redis

services.AddRedisHelper(configuration.GetSection(nameof(RedisHelperOptions)));

#endregion




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Autofac批量注入
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<CustomerAutofacModule>();
});
#endregion Autofac批量注入





OpenApiInfo info = configuration.GetSection("SwaggerInfo").Get<OpenApiInfo>();


services.AddControllers(opt =>
{
    #region 全局路由
    opt.UseCentralRoutePrefix(new RouteAttribute($"api/{info.Version}/[controller]/[action]"));
    #endregion

    #region jwt检测过滤器
    opt.Filters.Add(typeof(JwtVersionCheckFilter));
    #endregion
});


#region swagger jwt 验证
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //是否验证Issuer
        ValidIssuer = configuration["JwtInfo:Issuer"], //发行人Issuer
        ValidateAudience = true, //是否验证Audience
        ValidAudience = configuration["JwtInfo:Audience"], //订阅人Audience
        ValidateIssuerSigningKey = true, //是否验证SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtInfo:SecurityKey"])), //SecurityKey安全秘钥
        ValidateLifetime = true, //是否验证失效时间
        ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
        RequireExpirationTime = true,
    };
});



services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

#endregion





var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();

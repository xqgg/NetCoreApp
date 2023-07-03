using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Core.Service.Context;
//using Core.Redis;
using Core.Common.Modules;
using GC.WebApi.Common.Routes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Globalization;
using System.Drawing;
using ColinChang.RedisHelper;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

builder.Services.AddControllers();

//����EF�����ַ���
builder.Services.AddDbContext<NCDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("local") ?? throw new InvalidOperationException("Connection string 'WebApplication3Context' not found."));
});

services.AddScoped<RedisHelper>();



//services.AddSingleton<RedisOptions>()
//    .Configure<RedisOptions>(r => configuration.GetSection("RedisOptions:Default").Bind(r));




//services.BuildServiceProvider().GetRequiredService<RedisHelper>().Test();


#region ע��Redis

services.AddRedisHelper(configuration.GetSection(nameof(RedisHelperOptions)));

#endregion




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



#region Autofac����ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<CustomerAutofacModule>();
});
#endregion Autofac����ע��





OpenApiInfo info = configuration.GetSection("SwaggerInfo").Get<OpenApiInfo>();

#region ȫ��·��
services.AddControllers(opt =>
{
    opt.UseCentralRoutePrefix(new RouteAttribute($"api/{info.Version}/[controller]/[action]"));
});
#endregion


#region swagger jwt ��֤
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //�Ƿ���֤Issuer
        ValidIssuer = configuration["JwtInfo:Issuer"], //������Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidAudience = configuration["JwtInfo:Audience"], //������Audience
        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtInfo:SecurityKey"])), //SecurityKey��ȫ��Կ
        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
        ClockSkew = TimeSpan.FromSeconds(30), //����ʱ���ݴ�ֵ�������������ʱ�䲻ͬ�����⣨�룩
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

app.UseAuthorization();

app.MapControllers();

app.Run();

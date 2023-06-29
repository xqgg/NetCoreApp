using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Core.Service.Context;
using Core.Redis;
using Core.Common.Modules;

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



services.AddSingleton<RedisOptions>()
    .Configure<RedisOptions>(r => configuration.GetSection("RedisOptions:Default").Bind(r));




services.BuildServiceProvider().GetRequiredService<RedisHelper>().Test();




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Autofac����ע��
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule<CustomerAutofacModule>();
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, //�Ƿ���֤Issuer
        ValidIssuer = configuration["Jwt:Issuer"], //������Issuer
        ValidateAudience = true, //�Ƿ���֤Audience
        ValidAudience = configuration["Jwt:Audience"], //������Audience
        ValidateIssuerSigningKey = true, //�Ƿ���֤SecurityKey
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])), //SecurityKey
        ValidateLifetime = true, //�Ƿ���֤ʧЧʱ��
        ClockSkew = TimeSpan.FromSeconds(30), //����ʱ���ݴ�ֵ�������������ʱ�䲻ͬ�����⣨�룩
        RequireExpirationTime = true,
    };
});


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

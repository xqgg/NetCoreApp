using ColinChang.RedisHelper;
using Core.Enum;
using Core.IBusiness;
using Core.Models;
using Core.Service.Context;
using Core.ViewModel.Respons;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Core.Business
{
    public class SalesBusiness : ISalesBusiness
    {
        private readonly NCDbContext context;
        private readonly IRedisHelper redis;
        public SalesBusiness(NCDbContext dbContext, IRedisHelper redis)
        {

            context = dbContext;

            this.redis = redis;

        }

        public Task<int> Add(params SalesOrderDetail[] items)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddMillion()
        {
            List<SalesOrderDetail> orders = new List<SalesOrderDetail>();
            Random random = new Random();
            for (int i = 0; i < 1000000; i++)
            {

                SalesOrderDetail order = new SalesOrderDetail()
                {
                    CarrierTrackingNumber = "ABC123",
                    OrderQty = (short)random.Next(10),
                    ProductId = random.Next(1000),
                    SpecialOfferId = 1,
                    UnitPrice = (decimal)random.NextDouble() * 1000,
                    UnitPriceDiscount = 0m,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };
                orders.Add(order);
            }
            await context.AddRangeAsync(orders);
            int count = await context.SaveChangesAsync();

            if (count == 1000000)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Task<bool> Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Enable(int id, EnumEnable enable)
        {
            throw new NotImplementedException();
        }

        public Task<SalesOrderDetail> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SalesCalculationRespons>> GetSalesCalculation()
        {
            string key = "SalesCalculation";

            IEnumerable<SalesCalculationRespons> sales = await redis.PeekRangeAsync<SalesCalculationRespons>(key);
            if (sales.IsNullOrEmpty())
            {
                sales = await context.SalesOrderDetails

                    .GroupBy(s => s.SalesOrderId)
                    .Select(g => new SalesCalculationRespons()
                    {
                        SalesOrderID = g.Key,

                        OrderQty = g.Count(),
                        LineTotal = g.Sum(x => x.LineTotal),

                    })
                    .Take(1000)//前一千
                    .ToListAsync();

                foreach (var item in sales)
                {
                    await redis.EnqueueAsync(key, item);
                }
                await redis.KeyExpireAsync(key, TimeSpan.FromSeconds(30));
            }
            return sales.ToList();
        }

        public Task<bool> Update(params SalesOrderDetail[] items)
        {
            throw new NotImplementedException();
        }
    }


}

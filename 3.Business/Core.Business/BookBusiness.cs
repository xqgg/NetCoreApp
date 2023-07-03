using Core.Enum;
using Core.IBusiness;
using Core.Models;
using Core.Service.Context;
using Core.ViewModel.Respons;
using Microsoft.EntityFrameworkCore;

namespace Core.Business
{
    public class BookBusiness : IBookBusiness
    {
        private readonly NCDbContext context;

        public BookBusiness(NCDbContext dbContext)
        {

            context = dbContext;

        }
        public async Task<int> Add(params Book[] items)
        {

            await context.Books.AddRangeAsync(items);

            return await context.SaveChangesAsync();
        }

        public Task<bool> Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Enable(int id, EnumEnable enable)
        {
            throw new NotImplementedException();
        }

        public async Task<Book> GetById(int id)
        {
            return await context.Books.Where(b => b.ID == id).SingleOrDefaultAsync();





        }



        public Task<bool> Update(params Book[] items)
        {
            throw new NotImplementedException();
        }

        public async Task<BookPage> GetPage(int pageSize, int pageNumber)
        {



            var query = context.Books.OrderBy(b => b.Title);
            var totalCount = query.Count();
            var books = await query
                  .Skip((pageNumber - 1) * pageSize)
                  .Take(pageSize)
                  .ToListAsync();

            BookPage page = new BookPage()
            {
                Books = books,
                TotalCount = totalCount,
            };

            return page;

        }
    }
}

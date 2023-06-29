using Core.Model;
using Core.ViewModel.Respons;

namespace Core.IBusiness
{
    public interface IBookBusiness : Base.IBaseBusiness<Book>
    {
        public Task<BookPage> GetPage(int pageSize, int pageNumber);



    }
}

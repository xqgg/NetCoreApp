using Core.Models;

namespace Core.ViewModel.Respons
{
    public class BookPage
    {
        public List<Book> Books { get; set; }

        public int TotalCount { get; set; }
    }
}

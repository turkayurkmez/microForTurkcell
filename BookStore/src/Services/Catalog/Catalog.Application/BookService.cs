using Catalog.DataAccess.Repositories;
using Catalog.Domains;

namespace Catalog.Application
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IList<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }
    }
}

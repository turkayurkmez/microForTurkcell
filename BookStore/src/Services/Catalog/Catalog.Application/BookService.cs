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

        public Book GetBook(int id)
        {
            return _bookRepository.GetById(id);
        }

        public IList<Book> GetBooks()
        {
            return _bookRepository.GetAll();
        }
    }
}

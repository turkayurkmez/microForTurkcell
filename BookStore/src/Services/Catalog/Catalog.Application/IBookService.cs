using Catalog.Domains;

namespace Catalog.Application
{
    public interface IBookService
    {
        IList<Book> GetBooks();

    }
}

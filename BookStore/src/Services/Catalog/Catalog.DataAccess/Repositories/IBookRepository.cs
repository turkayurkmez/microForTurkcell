using Catalog.Domains;

namespace Catalog.DataAccess.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        public IList<Book> SearchBooksByName(string name);
    }
}

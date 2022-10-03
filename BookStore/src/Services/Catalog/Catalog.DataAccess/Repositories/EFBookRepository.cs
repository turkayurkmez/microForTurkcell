using Catalog.DataAccess.Data;
using Catalog.Domains;

namespace Catalog.DataAccess.Repositories
{
    public class EFBookRepository : IBookRepository
    {
        private readonly CatalogDbContext context;

        public EFBookRepository(CatalogDbContext context)
        {
            this.context = context;
        }

        public IList<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public IList<Book> SearchBooksByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}

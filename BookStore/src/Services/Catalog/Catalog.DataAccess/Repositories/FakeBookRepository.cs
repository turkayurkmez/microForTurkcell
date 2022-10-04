using Catalog.Domains;

namespace Catalog.DataAccess.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        public IList<Book> GetAll()
        {
            return new List<Book>()
           {
               new Book { Id=1, Name="abc", Price=5, Description="Desc"},
               new Book { Id=2, Name="xyz", Price=5, Description="Desc"},
               new Book { Id=3, Name="def", Price=5, Description="Desc"},

           };
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Book> SearchBooksByName(string name)
        {
            return new List<Book>()
           {
               new Book { Id=1, Name="abc", Price=5, Description="Desc"},
               new Book { Id=2, Name="xyz", Price=5, Description="Desc"},
               new Book { Id=3, Name="def", Price=5, Description="Desc"},

           };
        }
    }
}

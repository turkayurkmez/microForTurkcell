using Catalog.Domains;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess.Data
{
    public static class PrepareDb
    {
        public static void Initialize(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.Database.Migrate();
            seedCategory(catalogDbContext);
            seedProducts(catalogDbContext);
        }

        private static void seedProducts(CatalogDbContext catalogDbContext)
        {
            if (!catalogDbContext.Books.Any())
            {
                var books = new List<Book>
                {
                    new Book{Name = "Vakıf", CategoryId=1, Price=5, Description="Isaac Asimow"},
                    new Book{Name = "O", CategoryId=2, Price=3, Description="Stephen King"}

                };
                catalogDbContext.Books.AddRange(books);
                catalogDbContext.SaveChanges();
            }

        }

        private static void seedCategory(CatalogDbContext catalogDbContext)
        {
            if (!catalogDbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category{Name = "Bilim Kurgu"},
                    new Category{Name = "Korku"}

                };
                catalogDbContext.Categories.AddRange(categories);
                catalogDbContext.SaveChanges();
            }


        }
    }
}

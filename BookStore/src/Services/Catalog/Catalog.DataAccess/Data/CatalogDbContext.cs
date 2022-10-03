using Catalog.Domains;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess.Data
{
    public class CatalogDbContext : DbContext
    {
        /*
         * docker pull mcr.microsoft.com/mssql/server:2019-latest
         * docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pa55W0rd" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2019-latest
         */
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        public CatalogDbContext(DbContextOptions<CatalogDbContext> dbContext) : base(dbContext)
        {

        }
    }
}

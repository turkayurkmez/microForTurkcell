using Catalog.Domains;

namespace Catalog.DataAccess.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        IList<T> GetAll();
        T GetById(int id);
    }
}

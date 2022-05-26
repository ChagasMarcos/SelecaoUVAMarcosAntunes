using System.Threading.Tasks;

namespace SelecaoUVA.Persistence.Contracts
{
    public interface IGenericPersist
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

    }
}

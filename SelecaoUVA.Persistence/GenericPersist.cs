using SelecaoUVA.Persistence.Config;
using SelecaoUVA.Persistence.Contracts;
using System.Threading.Tasks;

namespace SelecaoUVA.Persistence
{
    public class GenericPersist : IGenericPersist
    {
        private readonly ContextBase _context;

        public GenericPersist(ContextBase context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}

using Microsoft.EntityFrameworkCore;
using SelecaoUVA.Domain.Entities;
using SelecaoUVA.Persistence.Config;
using SelecaoUVA.Persistence.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelecaoUVA.Persistence
{
    public class UserPersist : GenericPersist, IUserPersist
    {
        private readonly ContextBase _context;
        public UserPersist(ContextBase context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            return await _context.Users.Where(x => x.Active == true).ToListAsync();
        }

        public async Task<User> GetUserByCPF(string cpf)
        {
            var query = _context.Users.Where(c => c.CPF == cpf);
           
            return await query.FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }
    }
}

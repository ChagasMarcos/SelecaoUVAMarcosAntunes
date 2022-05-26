using SelecaoUVA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelecaoUVA.Persistence.Contracts
{
    public interface IUserPersist : IGenericPersist
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int Id);
        Task<User> GetUserByCPF(string cpf);
    }
}

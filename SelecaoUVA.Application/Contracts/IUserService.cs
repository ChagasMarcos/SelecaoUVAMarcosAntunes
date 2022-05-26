using SelecaoUVA.Application.DTOs;
using SelecaoUVA.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelecaoUVA.Application.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> CreateUserAsync(UserDTO model);
        Task<UserUpdateDTO> UpdateUser(int Id, UserUpdateDTO model);
        Task<bool> DeleteUser(int Id);
        Task<User> GetUserByIdAsync(int Id);
    }
}

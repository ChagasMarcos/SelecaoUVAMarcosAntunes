using AutoMapper;
using SelecaoUVA.Application.Contracts;
using SelecaoUVA.Application.DTOs;
using SelecaoUVA.Application.Helpers;
using SelecaoUVA.Domain.Entities;
using SelecaoUVA.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SelecaoUVA.Application
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserPersist _userPersist;
        public UserService(IMapper mapper, IUserPersist userPersist)
        {
            _mapper = mapper;
            _userPersist = userPersist;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userPersist.GetAllUserAsync();
                if (users == null) return null;

                var userResult = _mapper.Map<IEnumerable<UserDTO>>(users);

                return userResult;

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao tentar listar usuários. Erro: {ex.Message}");
            }
        }


        public async Task<UserDTO> CreateUserAsync(UserDTO model)
        {
           if (!CPFValidator.IsValid(model.CPF))
              throw new Exception("O CPF é inválido.");

            var cpfValido = await _userPersist.GetUserByCPF(model.CPF);
            if (cpfValido == null)
            {
                try
                {
                    var user = _mapper.Map<User>(model);
                    user.CreationDate = DateTime.Now;
                    user.Active = true;
  
                    _userPersist.Add<User>(user);

                    if (await _userPersist.SaveChangesAsync())
                    {
                        var userReturn = await _userPersist.GetUserByIdAsync(user.Id);
                        return _mapper.Map<UserDTO>(userReturn);
                    }
                    return null;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Erro ao tentar cadastrar usuário. Erro: {ex.Message}");
                }
            }
            throw new Exception("Este CPF já foi cadastrado.");
        }
     

        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await _userPersist.GetUserByIdAsync(Id);
        }



        public async Task<UserUpdateDTO> UpdateUser(int Id, UserUpdateDTO model)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(Id);
                if (user == null) return null;

                _mapper.Map(model, user);
                _userPersist.Update<User>(user);
                if(await _userPersist.SaveChangesAsync())
                {
                    var userReturn = await _userPersist.GetUserByIdAsync(user.Id);
                    return _mapper.Map<UserUpdateDTO>(userReturn);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(int Id)
        {
            try
            {
                var user = await _userPersist.GetUserByIdAsync(Id);
                if (user == null) throw new Exception("Usuário não encontrado!");

                _userPersist.Delete<User>(user);
                return await _userPersist.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelecaoUVA.Application.Contracts;
using SelecaoUVA.Application.DTOs;
using System;
using System.Threading.Tasks;

namespace SelecaoUVAMarcosAntunes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                if (users == null) NoContent();

                return Ok(users);
            }
            catch(Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO model)
        {
                try
                {
                    var user = await _userService.CreateUserAsync(model);
                    if (user == null) NoContent();
                    return Ok(user);
                }
                catch (Exception ex)
                {
                    return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Usuário. Erro: {ex.Message}");
                }
        }


        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, UserUpdateDTO model)
        {
            try
            {
                var user = await _userService.UpdateUser(Id, model);
                if (user == null) NoContent();

                return Ok(user);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar eventos. Erro: {ex.Message}");
            }
        }


        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _userService.DeleteUser(Id);
                return Ok(new { message = "Usuário Excluído!" });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir Usuário. Erro: {ex.Message}");
            }
        }
        
    }
}

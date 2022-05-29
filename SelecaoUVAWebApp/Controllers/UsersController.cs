using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SelecaoUVA.Application.Contracts;
using SelecaoUVA.Application.DTOs;
using SelecaoUVA.Persistence.Config;
using System;
using System.Threading.Tasks;

namespace SelecaoUVAWebApp.Controllers
{
    public class UsersController : Controller
    {

        private readonly IUserService _userService;

        public UsersController(ContextBase context, IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersAsync());     
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserDTO user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                await _userService.CreateUserAsync(user);
                TempData["MSG_S"] = "Usuário Cadastrado";

                return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    UserDTO userReturn = new UserDTO();
                    userReturn = user;

                    TempData["MSG_E"] = ex.Message;
                    return RedirectToAction(nameof(Create), userReturn);            
                }
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UserUpdateDTO user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _userService.UpdateUser(id, user);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Opa, deu erro. Erro: {ex.Message}");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(int Id)
        {
            await _userService.DeleteUser(Id);
            return RedirectToAction(nameof(Index));
        }
       
    }
}

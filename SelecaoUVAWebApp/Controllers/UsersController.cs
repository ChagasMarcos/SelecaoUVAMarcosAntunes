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

        public async Task<IActionResult> Index()
        {
            return View(await _userService.GetAllUsersAsync());     
        }

        
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
                TempData["MSG_E"] = ex.Message;
                return RedirectToAction(nameof(Create), user);            
                }
            }
            return View(user);
        }


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
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _userService.DeleteUser(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        //private bool UserExists(int id)
        //{
        //    return _context.Users.Any(e => e.Id == id);
        //}
    }
}

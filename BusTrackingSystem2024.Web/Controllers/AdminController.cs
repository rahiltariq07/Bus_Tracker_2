using BusTrackingSystem2024.Application.DTOs;
using BusTrackingSystem2024.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BusTrackingSystem2024.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Admin/RegisterUser
        public IActionResult RegisterUser()
        {
            return View();
        }

        // POST: Admin/RegisterUser
        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegistrationDTO registrationDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(registrationDTO);
            }

            try
            {
                await _userService.RegisterUserAsync(registrationDTO);
                // Set a success message to display on the dashboard.
                TempData["SuccessMessage"] = "Account created successfully.";
                return RedirectToAction("Dashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while registering the user: " + ex.Message);
                return View(registrationDTO);
            }
        }
    }
}

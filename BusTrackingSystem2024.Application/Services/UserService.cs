using BusTrackingSystem2024.Application.DTOs;
using BusTrackingSystem2024.Application.Interfaces;
using BusTrackingSystem2024.Domain.Entities;
using BusTrackingSystem2024.Infrastructure.Data;  // Updated location for ApplicationDbContext
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BusTrackingSystem2024.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UserService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task RegisterUserAsync(UserRegistrationDTO registrationDTO)
        {
            // Create the Identity user (this data goes into AspNetUsers)
            var user = new IdentityUser
            {
                UserName = registrationDTO.Email,
                Email = registrationDTO.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registrationDTO.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception("User creation failed: " + errors);
            }

            // Ensure the role exists
            if (!await _roleManager.RoleExistsAsync(registrationDTO.Role))
            {
                throw new Exception($"Role '{registrationDTO.Role}' does not exist.");
            }

            // Add the user to the specified role
            await _userManager.AddToRoleAsync(user, registrationDTO.Role);

            // Add extra details into custom tables
            if (registrationDTO.Role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                var student = new Student
                {
                    IdentityUserId = user.Id,
                    FullName = registrationDTO.FullName,
                    RegistrationNumber = registrationDTO.RegistrationNumber
                };
                _context.Students.Add(student);
            }
            else if (registrationDTO.Role.Equals("Driver", StringComparison.OrdinalIgnoreCase))
            {
                var driver = new Driver
                {
                    IdentityUserId = user.Id,
                    FullName = registrationDTO.FullName,
                    LicenseNumber = registrationDTO.LicenseNumber  // Set the LicenseNumber
                };
                _context.Drivers.Add(driver);
            }

            // Save changes for the extra data
            await _context.SaveChangesAsync();
        }
    }
}
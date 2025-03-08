using BusTrackingSystem2024.Application.DTOs;
using System.Threading.Tasks;

namespace BusTrackingSystem2024.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(UserRegistrationDTO registrationDTO);
        // Additional user management methods can be defined here
    }
}

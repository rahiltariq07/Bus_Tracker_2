namespace BusTrackingSystem2024.Application.DTOs
{
    public class UserRegistrationDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // "Student" or "Driver"
        // For Student registration
        public string RegistrationNumber { get; set; }
        // For Driver registration
        public string LicenseNumber { get; set; }
    }
}

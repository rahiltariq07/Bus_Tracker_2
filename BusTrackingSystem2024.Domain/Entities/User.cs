namespace BusTrackingSystem2024.Domain.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords securely
    }
}

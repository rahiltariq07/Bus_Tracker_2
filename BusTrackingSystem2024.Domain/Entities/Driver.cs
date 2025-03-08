namespace BusTrackingSystem2024.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }  // FK to AspNetUsers.Id
        public string FullName { get; set; }
        public string LicenseNumber { get; set; }
        // Add additional driver-specific properties as needed
    }
}

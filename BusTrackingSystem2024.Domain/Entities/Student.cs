namespace BusTrackingSystem2024.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string IdentityUserId { get; set; }  // FK to AspNetUsers.Id
        public string FullName { get; set; }
        public string? RegistrationNumber { get; set; }  // Make it nullable if not provided
    }
}

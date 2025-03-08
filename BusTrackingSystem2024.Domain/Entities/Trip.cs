using System;

namespace BusTrackingSystem2024.Domain.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int StudentId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IsCancelled { get; set; }
        // Navigation properties for EF Core relationships
        public Driver Driver { get; set; }
        public Student Student { get; set; }
    }
}

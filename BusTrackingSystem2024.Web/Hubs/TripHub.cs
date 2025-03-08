using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace BusTrackingSystem2024.Web.Hubs
{
    public class TripUpdateDto
    {
        public string Type { get; set; }  // "DriverLocationUpdate", "StudentLocationUpdate", etc.
        public double DriverLat { get; set; }
        public double DriverLng { get; set; }
        public double StudentLat { get; set; }
        public double StudentLng { get; set; }
        public string StudentId { get; set; } // Unique identifier for the student
    }

    public class TripHub : Hub
    {
        public async Task UpdateStudentLocation(TripUpdateDto data)
        {
            data.Type = "StudentLocationUpdate";
            await Clients.All.SendAsync("ReceiveTripUpdate", data);
        }

        public async Task UpdateDriverLocation(TripUpdateDto data)
        {
            data.Type = "DriverLocationUpdate";
            await Clients.All.SendAsync("ReceiveTripUpdate", data);
        }

        public async Task EndTrip()
        {
            var data = new { Type = "TripEnded" };
            await Clients.All.SendAsync("ReceiveTripUpdate", data);
        }

        public async Task StudentPickedUp(TripUpdateDto data)
        {
            data.Type = "StudentPickedUp";
            await Clients.All.SendAsync("ReceiveTripUpdate", data);
        }

        public async Task CancelTrip(TripUpdateDto data)
        {
            data.Type = "TripCancelled";
            await Clients.All.SendAsync("ReceiveTripUpdate", data);
        }
    }
}

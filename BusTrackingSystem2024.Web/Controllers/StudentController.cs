using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusTrackingSystem2024.Web.Controllers
{
    [Authorize(Roles = "Student")]
    public class StudentController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CancelTrip()
        {
            // Implement the cancellation logic here (e.g., update the trip status in your database)
            // You may also send a SignalR notification to update the driver's map.
            return RedirectToAction("Dashboard");
        }
    }
}

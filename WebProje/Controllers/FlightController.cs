using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class FlightController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public IActionResult MainPage()
        {
            var l = o.Flights.ToList();
            return View(l);
        }
    }
}

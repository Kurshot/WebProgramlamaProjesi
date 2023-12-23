using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class FlightController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public IActionResult List()
        {
            var list = o.Flights.
                Include(x => x.departurePlace).
                Include(y=>y.arrivalPlace).
                Include(z=>z.Plane.PlaneType);
            return View(list.ToList());
        }
        [HttpPost]
        public IActionResult Add()
        {
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            return View();
        }
        public IActionResult Add(Flight f)
        {
            if (ModelState.IsValid)
            { 
                o.Add(f);
                o.SaveChanges();
                TempData["msj"] = "Uçuş eklendi";
                return RedirectToAction("List");
            }
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            return View();
        }
    }
}

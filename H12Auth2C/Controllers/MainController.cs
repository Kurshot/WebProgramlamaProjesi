using H12Auth2C.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext o;
        public MainController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult Main()
        {
            ViewBag.Departure = new SelectList(o.Cities, "Id", "Name");
            ViewBag.Arrival = new SelectList(o.Cities, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult List(int departurePlaceId,int arrivalPlaceId) 
        {

          var list = o.Flights.
              Include(x => x.departurePlace).
              Include(y => y.arrivalPlace).
              Include(z => z.Plane.PlaneType).Where(x => x.departurePlaceId == departurePlaceId&&x.arrivalPlaceId==arrivalPlaceId).ToList();
            return View(list); 
        }
    }
}

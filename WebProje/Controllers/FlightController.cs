using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class FlightController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public IActionResult List()
        { 
            var y = o.Flights.ToList();
            return View(y);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Flight f)
        {
            if (ModelState.IsValid)
            {
                o.Flights.Add(f);
                o.SaveChanges();
                return RedirectToAction("List");
            }
            return View();
        }
    }
}

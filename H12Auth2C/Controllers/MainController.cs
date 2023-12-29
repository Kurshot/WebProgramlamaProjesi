using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.XmlEncryption;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    public class MainController : Controller
    {
        private readonly ApplicationDbContext o;
        private readonly UserManager<UserDetails> _userManager;
        public MainController(ApplicationDbContext o,UserManager<UserDetails> userManager)
        {
            this.o = o;
            this._userManager = userManager;
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
            TempData["id"] = o.Flights.Where(x => x.departurePlaceId == departurePlaceId && x.arrivalPlaceId == arrivalPlaceId).Select(u=>u.Id).FirstOrDefault();
           return View(list);
        }
        [Authorize(Roles = "Admin,Traveller")]
        public async Task<IActionResult> TicketAdd()
        {
            TempData["msjmain"] = "";
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    ViewBag.UserId = user.Id;
                    var ticket = new Ticket
                    {
                        UserId = ViewBag.UserId
                    };

                    if (TempData.ContainsKey("id") && TempData["id"] is int flightId)
                    {
                        ticket.FlightId = flightId;
                        o.Add(ticket);
                        o.SaveChanges();
                        TempData["msjmain"] = "Bilet alınmıştır";
                        return RedirectToAction("Main");
                    }
                    else
                    {
                        TempData["msjmain"] = "Böyle bir uçuş yok";
                        return RedirectToAction("Main");
                    }

                }
                TempData["msjmain"] = "Böyle bir uçuş yok";
                return RedirectToAction("Main");
            }
            TempData["msjmain"] = "Lütfen giriş yapınız";
            return RedirectToAction("Main");
        }
    }
}

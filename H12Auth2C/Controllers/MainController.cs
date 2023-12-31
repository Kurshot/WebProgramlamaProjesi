using H12Auth2C.Data;
using H12Auth2C.Models;
using MessagePack.Formatters;
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
              Include(z => z.Plane.PlaneType).
              Where(x => x.departurePlaceId == departurePlaceId&&x.arrivalPlaceId==arrivalPlaceId).
              ToList();
            TempData["id"] = o.Flights.Where(x => x.departurePlaceId == departurePlaceId && x.arrivalPlaceId == arrivalPlaceId).Select(u=>u.Id).FirstOrDefault();
           return View(list);
        }
        [Authorize(Roles = "Admin,Traveller")]
        public async Task<IActionResult> TicketAdd(int SeatName)
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
                        UserId = ViewBag.UserId,
                        SeatNumber = SeatName,
                    };

                    if (TempData.ContainsKey("id") && TempData["id"] is int flightId)
                    {
                        var isSeatReserved = o.Flights
                           .Where(f => f.Id == flightId)
                           .SelectMany(f => f.Plane.PlaneType.Seats) 
                           .Any(s => s.SeatName == SeatName && s.IsReserve);
                        var planeTypeId = o.Flights
                             .Where(f => f.Id == flightId)
                             .Select(f => f.Plane.PlaneType.Id)
                             .FirstOrDefault();
                        if(isSeatReserved == false)
                        {
                            var buyTicket = o.Seats.FirstOrDefault(f => f.PlaneTypeId == planeTypeId && f.SeatName == SeatName);
                            if(buyTicket is not null) { buyTicket.IsReserve = true; }
                            ticket.FlightId = flightId;
                            o.Add(ticket);
                            o.SaveChanges();
                            TempData["msjmain"] = "Bilet alınmıştır";
                            return RedirectToAction("Main");
                        }
                        else
                        {
                            TempData["msjmain"] = "Bu koltuk dolu.";
                            return RedirectToAction("Main");
                        }
                        
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

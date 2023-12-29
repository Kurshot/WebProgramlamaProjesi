using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class FlightController : Controller
    {
        private readonly ApplicationDbContext o;
        public FlightController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Flights.
                Include(x => x.departurePlace).
                Include(y => y.arrivalPlace).
                Include(z => z.Plane.PlaneType);
            return View(list.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Flight f)
        {
            if (ModelState.IsValid)
            {
                if (f.departurePlaceId != f.arrivalPlaceId)
                {
                    o.Flights.Add(f);
                    o.SaveChanges();
                    TempData["msjf"] = "Uçuş eklendi";
                    return RedirectToAction("List");
                }
                TempData["msjf"] = "Kalkış yeri ile varış yeri aynı olamaz.";
                return RedirectToAction("List");
            }
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                TempData["msjf"] = "Lütfen bir uçuş seçiniz";
                return View();
            }
            var ticket = o.Flights.Include(x => x.Tickets).FirstOrDefault(y => y.Id == id);
            if (ticket is null)
            {
                TempData["msjf"] = "Böyle bir uçuş bulunamadi";
                return View();
            }
            if (ticket.Tickets.Count > 0)
            {
                TempData["msjf"] = "Bu uçuşa ait biletler var önce biletleri siliniz";
                return View();
            }
            o.Flights.Remove(ticket);
            o.SaveChanges();
            TempData["msjf"] = "Uçuş silindi";
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            if (id == null)
            {
                TempData["msjf"] = "Lütfen bir uçuş seçiniz";
                return View();
            }
            var ticket = o.Flights.Include(x => x.Tickets).FirstOrDefault(y => y.Id == id);
            if (ticket is null)
            {
                TempData["msjf"] = "Böyle bir uçuş bulunamadi";
                return View();
            }
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Flight f)
        {
            if (id != f.Id)
            {
                TempData["msjf"] = "Böyle bir uçuş yok";
                return View();
            }
            if (ModelState.IsValid)
            {
                o.Flights.Update(f);
                o.SaveChanges();
                TempData["msjf"] = "Uçuş düzenlendi";
                return RedirectToAction("List");
            }
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            TempData["msjf"] = "Uçuş güncelleme başarısız";
            return View();
        }
    }
}

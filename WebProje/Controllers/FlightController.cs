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
                o.Flights.Add(f);
                o.SaveChanges();
                TempData["msj"] = "Uçuş eklendi";
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
                TempData["hata"] = "Lütfen bir uçuş seçiniz";
                return View();
            }
            var ticket = o.Flights.Include(x => x.Tickets).FirstOrDefault(y => y.Id == id);
            if(ticket is null)
            {
                TempData["hata"] = "Böyle bir uçuş bulunamadi";
                return View();
            }
            if (ticket.Tickets.Count>0)
            {
                TempData["hata"] = "Bu uçuşa ait biletler var önce biletleri siliniz";
                return View();
            }
            o.Flights.Remove(ticket);
            o.SaveChanges();
            TempData["msj"] = "Uçuş silindi";
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            if (id == null)
            {
                TempData["hata"] = "Lütfen bir uçuş seçiniz";
                return View();
            }
            var ticket = o.Flights.Include(x => x.Tickets).FirstOrDefault(y => y.Id == id);
            if (ticket is null)
            {
                TempData["hata"] = "Böyle bir uçuş bulunamadi";
                return View();
            }
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Edit(int ?id,Flight f)
        {
            if (id != f.Id)
            {
                TempData["hata"] = "Böyle bir uçuş yok";
                return View();
            }
            if (ModelState.IsValid)
            {
                o.Flights.Update(f);
                o.SaveChanges();
                TempData["msj"] = "Uçuş düzenlendi";
                return RedirectToAction("List");
            }
            ViewBag.departurePlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.arrivalPlaceId = new SelectList(o.Airports, "Id", "AirportName");
            ViewBag.PlaneId = new SelectList(o.PlaneTypes, "Id", "modelName");
            TempData["hata"] = "Uçuş güncelleme başarısız";
            return View();
        }
    }
}

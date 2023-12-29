using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class AirportController : Controller
    {
        private readonly ApplicationDbContext o;
        public AirportController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Airports.Include(x => x.City);
            return View(list.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Airport a)
        {
            if (ModelState.IsValid)
            {
                o.Airports.Add(a);
                o.SaveChanges();
                TempData["msjairport"] = "Havalimanı eklendi";
                return RedirectToAction("List");
            }
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjairport"] = "Lütfen bir havalimanı seçiniz";
                return RedirectToAction("List");
            }
            var flight = o.Airports.Include(x => x.Flights).Include(y => y.Flights1).FirstOrDefault(a => a.Id == id);

            if (flight is null)
            {
                TempData["msjairport"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            if (flight.Flights.Count > 0)
            {
                TempData["msjairport"] = "Bu havalimanına ait biletler var önce biletleri siliniz";
                return RedirectToAction("List");
            }
            o.Airports.Remove(flight);
            o.SaveChanges();
            TempData["msjairport"] = "Havalimanı silindi";
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            if (id == null)
            {
                TempData["msjairport"] = "Lütfen bir havalimanı seçiniz";
                return RedirectToAction("List");
            }
            var flight = o.Airports.Include(x => x.Flights).Include(y => y.Flights1).FirstOrDefault(a => a.Id == id);

            if (flight is null)
            {
                TempData["msjairport"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            return View(flight);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Airport a)
        {
            if (a.Id != id)
            {
                TempData["msjairport"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Airports.Update(a);
                o.SaveChanges();
                TempData["msjairport"] = "Havalimanı güncellenmiştir";
                return RedirectToAction("List");
            }
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            TempData["msjairport"] = "Havalimanı güncelleme işlemi başarısız";
            return View();
        }
    }
}

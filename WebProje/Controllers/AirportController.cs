using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class AirportController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
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
                TempData["msja"] = "Havalimanı eklendi";
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
                TempData["msja"] = "Lütfen bir havalimanı seçiniz";
                return RedirectToAction("List");
            }
            var flight = o.Airports.Include(x => x.Flights).Include(y=>y.Flights1).FirstOrDefault(a=>a.Id == id);
           
            if (flight is null)
            {
                TempData["msja"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            if (flight.Flights.Count > 0)
            {
                TempData["msja"] = "Bu havalimanına ait biletler var önce biletleri siliniz";
                return RedirectToAction("List");
            }
            o.Airports.Remove(flight);
            o.SaveChanges();
            TempData["msja"] = "Havalimanı silindi";
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            if (id == null)
            {
                TempData["msja"] = "Lütfen bir havalimanı seçiniz";
                return RedirectToAction("List");
            }
            var flight = o.Airports.Include(x => x.Flights).Include(y => y.Flights1).FirstOrDefault(a => a.Id == id);

            if (flight is null)
            {
                TempData["msja"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            return View(flight);
        }
        [HttpPost]
        public IActionResult Edit(int ?id,Airport a)
        {
            if (a.Id!= id)
            {
                TempData["msja"] = "Böyle bir havalimanı bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Airports.Update(a);
                o.SaveChanges();
                TempData["msja"] = "Havalimanı güncellenmiştir";
                return RedirectToAction("List");
            }
            ViewBag.CityName = new SelectList(o.Cities, "Id", "Name");
            TempData["msja"] = "Havalimanı güncelleme işlemi başarısız";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webproje.Data;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CityController : Controller
    {
        private readonly ApplicationDbContext o;
        public CityController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public  IActionResult List()
        {
            var list = o.Cities.Include(k => k.Country);
            return View(list.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CountryName = new SelectList(o.Countries, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Add(City c)
        {
            if (ModelState.IsValid)
            {
                o.Cities.Add(c);
                o.SaveChanges();
                TempData["msjco"] = "Şehir başarılı bir şekilde eklenmiştir";
                return RedirectToAction("List");
            }
            ViewBag.CountryName = new SelectList(o.Countries, "Id", "Name");
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjco"] = "Lütfen şehir seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Cities.Include(x => x.Airports).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şehir bulunamadı";
                return RedirectToAction("List");
            }
            if (c.Airports.Count > 0)
            {
                TempData["msjco"] = "Bu şehirin havalimanları var lütfen önce onları siliniz";
                return RedirectToAction("List");
            }
            o.Cities.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.CountryName = new SelectList(o.Countries, "Id", "Name");
            if (id is null)
            {
                TempData["msjco"] = "Lütfen bir şehir seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Cities.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şehir bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, City c)
        {
            if (id != c.Id)
            {
                TempData["msjco"] = "Böyle bir şehir bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Cities.Update(c);
                o.SaveChanges();
                TempData["msjco"] = "Seçilen şehir güncellenmiştir";
                return RedirectToAction("List");
            }
            ViewBag.CountryName = new SelectList(o.Countries, "Id", "Name");
            TempData["msjco"] = "Hata !";
            return View();
        }
    }
}

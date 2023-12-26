using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webproje.Data;
using WebProje.Models;

namespace webproje.Controllers
{
    public class PlaneTypeController : Controller
    {
        private readonly ApplicationDbContext o;
        public PlaneTypeController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.PlaneTypes.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PlaneType pt)
        {
            if (ModelState.IsValid)
            {
                o.PlaneTypes.Add(pt);
                o.SaveChanges();
                TempData["msjco"] = "Uçaktipi başarılı bir şekilde eklenmiştir";
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjco"] = "Lütfen uçak modeli seçiniz";
                return RedirectToAction("List");
            }
            var c = o.PlaneTypes.Include(x => x.Planes).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir uçak modeli bulunamadı.";
                return RedirectToAction("List");
            }
            if (c.Planes.Count > 0)
            {
                TempData["msjco"] = "Bu uçak modelinden kullanılan uçaklar var lütfen önce uçakları siliniz.";
                return RedirectToAction("List");
            }
            TempData["msjco"] = "Uçak türü kaldırıldı.";
            o.PlaneTypes.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["msjco"] = "Lütfen bir uçak modeli seçiniz";
                return RedirectToAction("List");
            }
            var c = o.PlaneTypes.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir uçak türü bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, PlaneType pt)
        {
            if (id != pt.Id)
            {
                TempData["msjco"] = "Böyle bir uçak modeli  bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.PlaneTypes.Update(pt);
                o.SaveChanges();
                TempData["msjco"] = "Seçilen ülke güncellenmiştir";
                return RedirectToAction("List");
            }
            TempData["msjco"] = "Hata !";
            return View();
        }
    }
}
    

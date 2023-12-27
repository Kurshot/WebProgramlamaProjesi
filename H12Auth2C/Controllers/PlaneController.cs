using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class PlaneController : Controller
    {
        private readonly ApplicationDbContext o;
        public PlaneController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Planes.Include(k => k.PlaneType).Include(y => y.Company);
            return View(list.ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.CompanyName = new SelectList(o.Company, "Id", "Name");
            ViewBag.PlaneTypeName = new SelectList(o.PlaneTypes, "Id", "modelName");
            return View();
        }
        [HttpPost]
        public IActionResult Add(Plane c)
        {
            if (ModelState.IsValid)
            {
                o.Planes.Add(c);
                o.SaveChanges();
                TempData["msjco"] = "Uçak başarılı bir şekilde eklenmiştir.";
                return RedirectToAction("List");
            }
            ViewBag.CompanyName = new SelectList(o.Company, "Id", "Name");
            ViewBag.PlaneTypeName = new SelectList(o.PlaneTypes, "Id", "modelName");
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjco"] = "Lütfen uçak seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Planes.Include(x => x.Flights).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir uçak bulunamadı";
                return RedirectToAction("List");
            }
            if (c.Flights.Count > 0)
            {
                TempData["msjco"] = "Bu uçağın uçuşu var lütfen önce uçuşu iptal ediniz";
                return RedirectToAction("List");
            }
            o.Planes.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.CompanyName = new SelectList(o.Company, "Id", "Name");
            ViewBag.PlaneTypeName = new SelectList(o.PlaneTypes, "Id", "modelName");
            if (id is null)
            {
                TempData["msjco"] = "Lütfen bir uçak seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Planes.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir uçak bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Plane c)
        {
            if (id != c.Id)
            {
                TempData["msjco"] = "Böyle bir uçak bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Planes.Update(c);
                o.SaveChanges();
                TempData["msjco"] = "Seçilen uçak güncellenmiştir";
                return RedirectToAction("List");
            }
            ViewBag.CompanyName = new SelectList(o.Company, "Id", "Name");
            ViewBag.PlaneTypeName = new SelectList(o.PlaneTypes, "Id", "modelName");
            TempData["msjco"] = "Hata !";
            return View();
        }
    }
}

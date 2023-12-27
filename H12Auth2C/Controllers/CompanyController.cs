using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext o;
        public CompanyController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Company.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Company c)
        {
            if (ModelState.IsValid)
            {
                o.Company.Add(c);
                o.SaveChanges();
                TempData["msjco"] = "Şirket başarılı bir şekilde eklenmiştir";
                return RedirectToAction("List");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjco"] = "Lütfen şirket seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Company.Include(x => x.Planes).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadı";
                return RedirectToAction("List");
            }
            if (c.Planes.Count > 0)
            {
                TempData["msjco"] = "Bu şirketin uçakları var lütfen önce uçakları siliniz";
                return RedirectToAction("List");
            }
            TempData["msjco"] = "Şirket başarıyla silindi.";
            o.Company.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["msjco"] = "Lütfen bir şirket seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Company.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Company c)
        {
            if (id != c.Id)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Company.Update(c);
                o.SaveChanges();
                TempData["msjco"] = "Seçilen şirket güncellenmiştir";
                return RedirectToAction("List");
            }
            TempData["msjco"] = "Hata !";
            return View();
        }
    }
}

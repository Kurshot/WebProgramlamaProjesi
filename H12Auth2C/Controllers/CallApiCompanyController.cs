using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CallApiCompanyController : Controller
    {
        private readonly ApplicationDbContext o;
        public CallApiCompanyController(ApplicationDbContext o)
        {
            this.o = o;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Company> c = new List<Company>();
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7090/api/ApiCompany");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            c = JsonConvert.DeserializeObject<List<Company>>(jsonResponse);
            return View(c);
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
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjco"] = "Lütfen şirket seçiniz";
                return RedirectToAction("Index");
            }
            var c = o.Company.Include(x => x.Planes).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadı";
                return RedirectToAction("Index");
            }
            if (c.Planes.Count > 0)
            {
                TempData["msjco"] = "Bu şirketin uçakları var lütfen önce uçakları siliniz";
                return RedirectToAction("Index");
            }
            TempData["msjco"] = "Şirket başarıyla silindi.";
            o.Company.Remove(c);
            o.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["msjco"] = "Lütfen bir şirket seçiniz";
                return RedirectToAction("Index");
            }
            var c = o.Company.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadı";
                return RedirectToAction("Index");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Company c)
        {
            if (id != c.Id)
            {
                TempData["msjco"] = "Böyle bir şirket bulunamadi";
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid)
            {
                o.Company.Update(c);
                o.SaveChanges();
                TempData["msjco"] = "Seçilen şirket güncellenmiştir";
                return RedirectToAction("Index");
            }
            TempData["msjco"] = "Hata !";
            return View();
        }
    }
}

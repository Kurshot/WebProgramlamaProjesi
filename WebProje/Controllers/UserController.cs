using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class UserController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public IActionResult List()
        {
            var list = o.Users.ToList();
            return View(list);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(User u)
        {
            if (ModelState.IsValid)
            {
                o.Users.Add(u);
                o.SaveChanges();
                TempData["msju"] = u.Name + "adlı kullanıcı eklendi.";
                return RedirectToAction("List");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msju"] = "Lütfen bir kullanıcı seçiniz";
                return RedirectToAction("List");
            }
            var ticket = o.Users.Include(x => x.Ticket).FirstOrDefault(x => x.Id == id);
            if (ticket is null)
            {
                TempData["msju"] = "Böyle bir kullanıcı yok";
                return RedirectToAction("List");
            }
            if (ticket.Ticket.Count > 0)
            {
                TempData["msju"] = "Kullanıcın bileti var lütfen bileti iptal ediniz";
                return RedirectToAction("List");
            }
            o.Users.Remove(ticket);
            o.SaveChanges();
            TempData["msju"] = ticket.Name + " Kullanıcı silinmiştir";
            return RedirectToAction("List");
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                TempData["msju"] = "Lütfen bir kullanıcı seçiniz";
                return RedirectToAction("List");
            }
            var ticket = o.Users.Include(x => x.Ticket).FirstOrDefault(x => x.Id == id);
            if (ticket is null)
            {
                TempData["msju"] = "Böyle bir kullanıcı yok";
                return RedirectToAction("List");
            }
            return View(ticket);
        }
        [HttpPost]
        public IActionResult Edit(int? id, User u)
        {
            if (id != u.Id)
            {
                TempData["msju"] = "Böyle bir kullanıcı yok";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Users.Update(u);
                o.SaveChanges();
                TempData["msju"] = u.Name + " güncellendi";
                return RedirectToAction("List");
            }
            TempData["msju"] = "Hata";
            return RedirectToAction("List");
        }
    }
}

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
                var role = new Rolles
                {
                    roleTypeId = 2,
                    UserId = u.Id
                };
                o.Rolles.Add(role);
                o.SaveChanges();
                return RedirectToAction("List");
            }
            return View();
        }
    }
}

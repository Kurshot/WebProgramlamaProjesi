using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class UserController : Controller
    {
        private readonly OriAirlinesContext o;
        public UserController(OriAirlinesContext o)
        {
            this.o = o;
        }
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
                return RedirectToAction("List");
            }
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CityController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public  IActionResult Index()
        {
            var list = o.Cities.Include(k => k.Country);
            return View(list.ToList());
        }
    }
}

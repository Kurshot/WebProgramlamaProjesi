using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CityController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public async Task<IActionResult> Index()
        {
            var list = o.Cities.Include(k => k.Country);
            return View(await list.ToListAsync());
        }
    }
}

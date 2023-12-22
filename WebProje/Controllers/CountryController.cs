using Microsoft.AspNetCore.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CountryController : Controller
    {
        public OriAirlinesContext o = new OriAirlinesContext();
        public IActionResult List()
        {
            var list = o.Countries.ToList();
            return View(list);
        }
    }
}

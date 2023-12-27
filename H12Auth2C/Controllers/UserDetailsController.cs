using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class UserDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

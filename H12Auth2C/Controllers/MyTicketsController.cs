using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    public class MyTicketsController : Controller
    {
        private readonly ApplicationDbContext o;
        private readonly UserManager<UserDetails> _userManager;
        public MyTicketsController(ApplicationDbContext o, UserManager<UserDetails> userManager)
        {
            this.o = o;
            this._userManager = userManager;
        }
        [Authorize(Roles = "Admin,Traveller")]
        public async Task<IActionResult> MyTickets()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user is not null)
                {
                    string userID = user.Id;
                    var myflight = o.Ticket.Include(x => x.Flight)
                        .Include(y=>y.Flight.arrivalPlace)
                        .Include(x=>x.Flight.arrivalPlace.City)
                        .Include(x=>x.Flight.departurePlace.City)
                        .Include(z=>z.Flight.departurePlace)
                        .Where(y => y.UserId == userID).ToList();
                    return View(myflight);
                }
                TempData["msjmyticket"] = "Böyle bir kullanıcı yoktur";
                return RedirectToAction("Main", "Main");
            }
            TempData["msjmyticket"] = "Lütfen giriş yapınız.";
            return RedirectToAction("Main", "Main");
        }
    }
}

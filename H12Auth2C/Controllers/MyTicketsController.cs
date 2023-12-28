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
                TempData["msj"] = "Böyle bir kullanıcı yoktur";
                return RedirectToAction("Main", "Main");
            }
            TempData["msj"] = "Lütfen giriş yapınız.";
            return RedirectToAction("Main", "Main");
        }
        //public IActionResult MyTickets(string? userId)
        //{
        //    var uselist = o.Users.Where(x => x.Id == userId).ToList();
        //    if (uselist is null)
        //    {
        //        TempData["msj"] = "Böyle bir kullanıcı yok";
        //        return RedirectToAction("Main", "Main");
        //    }
        //    var myflight = o.Ticket.Include(x => x.Flight).Where(y => y.UserId == userId).ToList();
        //    return View(myflight);
        //}

    }
}

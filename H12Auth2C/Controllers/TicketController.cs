using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext o;
        public TicketController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Ticket.
               Include(x => x.User).
               Include(y => y.Flight.departurePlace.City).
               Include(z => z.Flight.arrivalPlace.City);
            return View(list.ToList());
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjt"] = "Lütfen bir bilet seçiniz";
                return View();
            }
            var ticket = o.Ticket.FirstOrDefault(y => y.Id == id);
            if (ticket is null)
            {
                TempData["msjt"] = "Böyle bir bilet bulunamadi";
                return View();
            }
            o.Ticket.Remove(ticket);
            o.SaveChanges();
            TempData["msjt"] = "Bilet silindi";
            return RedirectToAction("List");
        }
    }
}

using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class PlaneTypeController : Controller
    {
        private readonly ApplicationDbContext o;
        public PlaneTypeController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.PlaneTypes.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PlaneType pt)
        {
            if (ModelState.IsValid)
            {
                o.PlaneTypes.Add(pt);
                o.SaveChanges();
                for (int i = 1; i <= pt.Capacity; i++)
                {
                    var newSeat = new Seat
                    {
                        PlaneTypeId = pt.Id,
                        SeatName = i,
                        IsReserve = false
                    };
                    o.Seats.Add(newSeat);
                }
                o.SaveChanges();
                TempData["msjplanetype"] = "Uçaktipi başarılı bir şekilde eklenmiştir";
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjplanetype"] = "Lütfen uçak modeli seçiniz";
                return RedirectToAction("List");
            }
            var c = o.PlaneTypes.Include(x => x.Planes).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjplanetype"] = "Böyle bir uçak modeli bulunamadı.";
                return RedirectToAction("List");
            }
            if (c.Planes.Count > 0)
            {
                TempData["msjplanetype"] = "Bu uçak modelinden kullanılan uçaklar var lütfen önce uçakları siliniz.";
                return RedirectToAction("List");
            }
            TempData["msjplanetype"] = "Uçak türü kaldırıldı.";
            o.PlaneTypes.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["msjplanetype"] = "Lütfen bir uçak modeli seçiniz";
                return RedirectToAction("List");
            }
            var c = o.PlaneTypes.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjplanetype"] = "Böyle bir uçak türü bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, PlaneType pt)
        {
            if (id != pt.Id)
            {
                TempData["msjplanetype"] = "Böyle bir uçak modeli  bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.PlaneTypes.Update(pt);
                o.SaveChanges();
                TempData["msjplanetype"] = "Seçilen ülke güncellenmiştir";
                return RedirectToAction("List");
            }
            TempData["msjplanetype"] = "Hata !";
            return View();
        }
    }
}

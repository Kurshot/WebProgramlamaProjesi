﻿using H12Auth2C.Data;
using H12Auth2C.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class CountryController : Controller
    {
        private readonly ApplicationDbContext o;
        public CountryController(ApplicationDbContext o)
        {
            this.o = o;
        }
        public IActionResult List()
        {
            var list = o.Countries.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Country c)
        {
            if (ModelState.IsValid)
            {
                o.Countries.Add(c);
                o.SaveChanges();
                TempData["msjcountry"] = "Ülke başarılı bir şekilde eklenmiştir";
                return RedirectToAction("List");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                TempData["msjcountry"] = "Lütfen ülke seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Countries.Include(x => x.Cities).FirstOrDefault(y => y.Id == id);
            if (c is null)
            {
                TempData["msjcountry"] = "Böyle bir ülke bulunamadı";
                return RedirectToAction("List");
            }
            if (c.Cities.Count > 0)
            {
                TempData["msjcountry"] = "Bu ülkenin şehirleri var lütfen önce şehirleri siliniz";
                return RedirectToAction("List");
            }
            TempData["msjcountry"] = "Ülke başarıyla silindi.";
            o.Countries.Remove(c);
            o.SaveChanges();
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                TempData["msjcountry"] = "Lütfen bir ülke seçiniz";
                return RedirectToAction("List");
            }
            var c = o.Countries.FirstOrDefault(x => x.Id == id);
            if (c is null)
            {
                TempData["msjcountry"] = "Böyle bir ülke bulunamadı";
                return RedirectToAction("List");
            }
            return View(c);
        }
        [HttpPost]
        public IActionResult Edit(int? id, Country c)
        {
            if (id != c.Id)
            {
                TempData["msjcountry"] = "Böyle bir ülke bulunamadi";
                return RedirectToAction("List");
            }
            if (ModelState.IsValid)
            {
                o.Countries.Update(c);
                o.SaveChanges();
                TempData["msjcountry"] = "Seçilen ülke güncellenmiştir";
                return RedirectToAction("List");
            }
            TempData["msjcountry"] = "Hata !";
            return View();
        }
    }
}

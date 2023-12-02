using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web_Programlama_Dersi_Proje_Ödevi.Data;
using Web_Programlama_Dersi_Proje_Ödevi.Models;

namespace Web_Programlama_Dersi_Proje_Ödevi.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddProduct()
        {
            var newProduct = new Product
            {
                FirstName = "deneme isim"
            };

            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("ListProducts");
        }

        public IActionResult ListProducts()
        {
            var _allProducts = _context.Products.ToList();
            
            ViewBag.Products = _allProducts;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
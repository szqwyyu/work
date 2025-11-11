using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;
using System.Diagnostics;

namespace PetShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var featuredProducts = _context.Products.Take(3).ToList();
            var services = _context.Services.Take(3).ToList();

            ViewBag.FeaturedProducts = featuredProducts;
            ViewBag.Services = services;

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(ContactMessage message)
        {
            if (ModelState.IsValid)
            {
                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Сообщение успешно отправлено!" });
            }
            return Json(new { success = false, message = "Пожалуйста, заполните все поля правильно." });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
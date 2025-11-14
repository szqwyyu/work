using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;
using System.Collections.Generic;

namespace PetShop.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // РАСКОММЕНТИРУЙТЕ:
            var services = _context.Services.Where(s => s.IsActive).ToList();

            return View("~/Views/Home/Services.cshtml", services);
        }

        [HttpGet]
        public IActionResult GetAllServices()
        {
            // РАСКОММЕНТИРУЙТЕ:
            var services = _context.Services
                .Where(s => s.IsActive)
                .Select(s => new
                {
                    id = s.Id,
                    title = s.Title,
                    description = s.Description,
                    price = s.Price,
                    duration = s.Duration,
                    imageUrl = s.ImageUrl
                })
                .ToList();

            return Json(services);
        }

        [HttpGet]
        public IActionResult GetServiceDetails(int id)
        {
            // РАСКОММЕНТИРУЙТЕ:
            var services = _context.Services.FirstOrDefault(s => s.Id == id);

            return Json(services);
        }

        [HttpPost]
        public IActionResult BookService([FromBody] ServiceBooking booking)
        {
            if (ModelState.IsValid)
            {
                return Json(new { success = true, message = "Запись на услугу успешно оформлена!" });
            }
            return Json(new { success = false, message = "Пожалуйста, заполните все поля правильно." });
        }
    }

    public class ServiceBooking
    {
        public string ServiceName { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string PetName { get; set; } = string.Empty;
        public string PetType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
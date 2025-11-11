using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;

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
            var services = _context.Services.Where(s => s.IsActive).ToList();
            return View(services);
        }

        [HttpGet]
        public IActionResult GetServiceDetails(int id)
        {
            var service = _context.Services.FirstOrDefault(s => s.Id == id);
            return Json(service);
        }
    }
}
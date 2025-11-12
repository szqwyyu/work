using System.Linq;                    // Take, ToList
using System.Threading.Tasks;         // Task<>
using Microsoft.Extensions.Logging;  // ILogger<T>
using Microsoft.AspNetCore.Mvc;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Indexы()
        {
            var products = _context.Products.Where(p => p.IsAvailable).ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult GetProductsByCategory(string category)
        {
            var products = _context.Products
                .Where(p => p.Category == category && p.IsAvailable)
                .ToList();

            return Json(products);
        }
    }
}
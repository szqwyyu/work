using Microsoft.AspNetCore.Mvc;

namespace PetShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string Email, string Password)
        {
            // Здесь потом добавишь проверку пользователя
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(string Username, string Email, string Password)
        {
            // Здесь потом добавишь регистрацию в базе
            return RedirectToAction("Login");
        }
    }
}

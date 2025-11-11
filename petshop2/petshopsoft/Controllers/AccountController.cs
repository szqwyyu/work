using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using PetShop.Data;
using PetShop.Models;

namespace PetShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, existingUser.Username),
                    new Claim(ClaimTypes.Email, existingUser.Email)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
            }

            return Json(new { success = false, message = "Неверное имя пользователя или пароль" });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Username == user.Username))
            {
                return Json(new { success = false, message = "Пользователь с таким именем уже существует" });sssss
            }

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return Json(new { success = false, message = "Пользователь с таким email уже существует" });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Регистрация успешна! Теперь вы можете войти." });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
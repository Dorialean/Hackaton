using Hackathon.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Controllers
{
    public class VerificationController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserLogin userLogin)
        {
            return RedirectToAction("Verification", "Login");
        }

        public IActionResult Login(UserLogin userLogin)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

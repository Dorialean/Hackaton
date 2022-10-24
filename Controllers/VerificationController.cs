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
            return RedirectToAction("Auth");
        }
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Auth(UserLogin userLogin)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

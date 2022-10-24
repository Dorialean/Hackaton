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
        public IActionResult Register(UserAndData info)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}

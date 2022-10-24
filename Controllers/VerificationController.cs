using Hackathon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Hackathon.Controllers
{
    public class VerificationController : Controller
    {
        private HackathonDbContext _dbContext;
        private SHA256 sha256;
        private const string BAD_REQUEST_TEXT = "Вы не вписали данные для авторизаци, вернитесь назад и впишите.";

        public VerificationController(HackathonDbContext dbContext)
        {
            _dbContext = dbContext;
            sha256 = SHA256.Create();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterInfo userLogin)
        {
            if (userLogin?.Username == null || userLogin?.Password == null)
                return BadRequest(BAD_REQUEST_TEXT);
            if(userLogin?.Username != null && userLogin?.Username != null)
            {
                //Добавить проверку на существующего пользователя
                _dbContext.UserLogins.Add(new UserLogin() 
                {
                    Username = userLogin.Username,
                    Password = sha256.ComputeHash(Encoding.ASCII.GetBytes(userLogin.Password)) //Сюда надо добавить Salt
                });
            }
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
            if (userLogin?.Username == null || userLogin?.Password == null)
                return BadRequest(BAD_REQUEST_TEXT);

            return RedirectToAction("Index", "Home");
        }
    }
}

using System.Security.Claims;
using Hackathon.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

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
                if (!_dbContext.UserLogins.Select(x => x.Username).Any(x => x == userLogin.Username))
                {
                    var user = new UserLogin(){Username = userLogin.Username, Password = sha256.ComputeHash(Encoding.ASCII.GetBytes(userLogin.Password))};
                    _dbContext.UserLogins.Add(new UserLogin() 
                    {
                        Username = userLogin.Username,
                        Password = sha256.ComputeHash(Encoding.ASCII.GetBytes(userLogin.Password)) //Сюда надо добавить Salt
                    });
                    _dbContext.SaveChanges();
                    
                    //Cookie auth
                    var claims = new List<Claim>(){new Claim(ClaimTypes.Name,user.Username)};
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));
                    
                    return RedirectToAction("Auth", user);
                }
            }
            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Auth()
        {
            if (HttpContext.User.Identity.IsAuthenticated && HttpContext.User.Identity is not null)
            {
                var user = _dbContext.UserLogins.FirstOrDefault(x => x.Username == HttpContext.User.Identity.Name);
                if (user is null)
                {
                    return RedirectToAction("Register");
                }
                return RedirectToAction("UserSpace", "Home", user);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Auth(RegisterInfo userLogin)
        {
            if (userLogin?.Username == null || userLogin?.Password == null)
                return BadRequest(BAD_REQUEST_TEXT);
            var user = _dbContext.UserLogins.First(x => x.Username == userLogin.Username && x.Password == Encoding.ASCII.GetBytes(userLogin.Password));

            return RedirectToAction("UserSpace", "Home", user);
        }
    }
}

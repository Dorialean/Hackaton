using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hackathon.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private HackathonDbContext _dbContext;
    public HomeController(ILogger<HomeController> logger, HackathonDbContext dbcontext)
    {
        _logger = logger;
        _dbContext = dbcontext;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Dashboard()
    {
        return View();
    }   
    
    [Authorize]
    public IActionResult Courses()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Forum()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Timetable()
    {
        return View();
    }
    [HttpGet]
    public IActionResult UserSpace()
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult UserSpace(UserLogin userLogin)
    {
        var userAndData = new UserAndData(){ UserLogixn = userLogin};
        return View(userAndData);
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult UserSpaceSave(UserAndData userAndData)
    {
        var userId = _dbContext.UserLogins.FirstOrDefault(x => x.Username == HttpContext.User.Identity.Name).UserId;
        var user = new UserData()
        {
            UserDataId = userId, FirstName = userAndData.UserData.FatherName,
            LastName = userAndData.UserData.LastName, 
            FatherName = userAndData.UserData.FatherName
        };
        _dbContext.UserData.Add(user);
        _dbContext.SaveChanges();
        
        return RedirectToAction("Index", "Home");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


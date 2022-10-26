using System.Diagnostics;
using System.Security.Claims;
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

        var authifo = ControllerContext.HttpContext.User.Identity?.Name;
        return View(new UserPageAndCoursesAndLectures()
        {
            UserLogin = _dbContext.UserLogins.First(u => u.Username == authifo),
            UserData = null,
            allCourses = _dbContext.Courses.ToList(),
            allLectures = _dbContext.Lectures.ToList()
        });
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
    public IActionResult UserSpace(UserLogin userLogin)
    {
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult UserSpace(UserPageAndCoursesAndLectures userLogin)
    {
        var userAndData = new UserAndData(){ UserLogin = userLogin.UserLogin};
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


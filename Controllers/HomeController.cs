using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hackathon.Models;
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
    
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Courses()
    {
        return View();
    }

    public IActionResult Forum()
    {
        return View();
    }

    public IActionResult Timetable()
    {
        return View();
    }

    public IActionResult UserSpace()
    {
        return View();
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}


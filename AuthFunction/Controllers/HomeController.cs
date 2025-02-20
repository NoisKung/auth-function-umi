using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthFunction.Models;

namespace AuthFunction.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [Authorize(Roles = "admin,hr,dev")]
    public IActionResult Index()
    {
        return View();
    }
    [Authorize(Roles = "admin")]
    public IActionResult Privacy()
    {
        return View();
    }
    [Authorize(Roles = "admin,hr")]
    public IActionResult Member()
    {
        return View();
    }
    [Authorize(Roles = "admin,dev")]
    public IActionResult Task()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using MenuApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MenuApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var menuList = new List<MenuModel>
            {
                new MenuModel { NameProduct = "Coca Cola 150 ml ", Price = 2.50 },
                new MenuModel { NameProduct = "Insalata di pollo", Price =  5.20 },
                new MenuModel { NameProduct = "Pizza Margherita", Price = 10.00 },
                new MenuModel { NameProduct = "Pizza 4 Formaggi", Price = 12.50 },
                new MenuModel { NameProduct = "Pz patatine fritte", Price = 3.50 },
                new MenuModel { NameProduct = "Insalata di riso", Price = 8.00 },
                new MenuModel { NameProduct = "Frutta di stagione", Price = 5.00 },
                new MenuModel { NameProduct = "Pizza fritta", Price = 5.00 },
                new MenuModel { NameProduct = "Piadina vegetariana", Price = 6.00},
                new MenuModel { NameProduct = "Panino Hamburger", Price = 7.90 },
            };
            return View(menuList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

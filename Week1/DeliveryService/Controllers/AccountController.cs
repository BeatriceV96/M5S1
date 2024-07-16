using Microsoft.AspNetCore.Mvc;

namespace DeliveryService.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}

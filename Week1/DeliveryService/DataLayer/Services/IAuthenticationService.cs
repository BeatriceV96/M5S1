using DeliveryService.DataLayer.Services.Models;

namespace DeliveryService.DataLayer.Services
{
    public interface IAuthenticationService
    {
        ApplicationUser Login(string username, string password);
    }
}

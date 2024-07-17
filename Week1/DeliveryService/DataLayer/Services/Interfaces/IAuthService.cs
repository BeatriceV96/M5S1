using DeliveryService.DataLayer.Services.Models;

namespace DeliveryService.DataLayer.Services
{
    public interface IAuthService
    {
        ApplicationUser Login(string username, string password);
    }
}

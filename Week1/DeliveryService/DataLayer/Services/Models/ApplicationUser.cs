namespace DeliveryService.DataLayer.Services.Models
{
    public class ApplicationUser
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public bool RememberMe { get; internal set; }
    }
}

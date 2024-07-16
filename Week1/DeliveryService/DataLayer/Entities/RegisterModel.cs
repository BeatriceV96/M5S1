namespace DeliveryService.DataLayer.Services.Models
{
    public class RegisterModel
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}

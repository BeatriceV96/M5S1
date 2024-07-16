using System.Threading.Tasks.Dataflow;

namespace DeliveryService.DataLayer.Services.Models
{
    public class AuthenticationService : IAuthenticationService
    {
        public ApplicationUser Login(string username, string password)
        {
            if (username == password)
                return new ApplicationUser { UserName = username, Password = password };
            throw new Exception("Utente non autenticato");
        }
    }
}


using System.Data.SqlClient;

namespace DeliveryService.DataLayer.Services.Models
{
    public class AuthService : IAuthService
    {
        private readonly SqlConnection context; //lo importo dopo aver installato il pacchetto System.Data.SqlClient
        public ApplicationUser Login(string username, string password)
        {
            if (username == password)
                return new ApplicationUser { UserName = username, Password = password };
            throw new Exception("Utente non autenticato");
        }
    }
}
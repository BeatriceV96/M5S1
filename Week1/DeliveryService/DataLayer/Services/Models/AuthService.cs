
using System.Data.SqlClient;


namespace DeliveryService.DataLayer.Services.Models
{
    public class AuthService : IAuthService
    {
        private readonly string connectionString; //lo importo dopo aver installato il pacchetto System.Data.SqlClient
        private const string LOGIN_COMMAND //mi preparo una stringa di comando per il login

            = "SELECT Username* FROM Users WHERE Username = @user AND Password = @pass"; //cosi posso lavorare su una tabella autenti
        public AuthService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("AuthDb"); // Ottiene correttamente la stringa di connessione
        }
        public ApplicationUser Login(string username, string password)
        {
            try
            {
                using var conn = new SqlConnection(connectionString); //mi connetto al db
                conn.Open(); //apro la connessione
                using var cmd = new SqlCommand(LOGIN_COMMAND, conn); //mi creo un comando
                cmd.Parameters.AddWithValue("@user", username); //aggiungo il parametro user
                cmd.Parameters.AddWithValue("@pass", password); //aggiungo il parametro password
                using var r = cmd.ExecuteReader(); //eseguo il comando
                if (r.Read()) //se trovo un risultato
                {
                    return new ApplicationUser { Password = password, UserName = username }; //ritorno l'utente
                }
            }
            catch (Exception ex)
            {
                // Gestire l'eccezione o registrare l'errore
            } return null;
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Services;


namespace EsercitazioneSettimanale1.DAO
{
    public class TrasgressoreDao : DaoBase
    {
        private const string SELECT_ALL_TRASGRESSORI = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc FROM Anagrafica";
        private const string SELECT_TRASGRESSORE_BY_ID = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc FROM Anagrafica WHERE IdAnagrafica = @id";
        private const string INSERT_TRASGRESSORE = "INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc) OUTPUT INSERTED.IdAnagrafica VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @codFisc)";
        private const string UPDATE_TRASGRESSORE = "UPDATE Anagrafica SET Cognome = @cognome, Nome = @nome, Indirizzo = @indirizzo, Citta = @citta, CAP = @cap, Cod_Fisc = @codFisc WHERE IdAnagrafica = @id";
        private const string DELETE_TRASGRESSORE = "DELETE FROM Anagrafica WHERE IdAnagrafica = @id";

        public TrasgressoreDao(IConfiguration configuration, ILogger<TrasgressoreDao> logger) : base(configuration, logger) { }

        public IEnumerable<TrasgressoreViewModel> GetAll()
        {
            List<TrasgressoreViewModel> result = new List<TrasgressoreViewModel>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_TRASGRESSORI, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TrasgressoreViewModel trasgressore = new TrasgressoreViewModel
                            {

                                Cognome = reader.GetString(1),
                                Nome = reader.GetString(2),
                                Indirizzo = reader.GetString(3),
                                Citta = reader.GetString(4),
                                CAP = reader.GetString(5),
                                CodFisc = reader.GetString(6)
                            };
                            result.Add(trasgressore);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("An error occurred while getting the trasgressori", ex);
            }
            return result;
        }
        public void Create(TrasgressoreViewModel trasgressore)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CodFisc)", conn))
                    {
                        cmd.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
                        cmd.Parameters.AddWithValue("@Nome", trasgressore.Nome);
                        cmd.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
                        cmd.Parameters.AddWithValue("@Citta", trasgressore.Citta);
                        cmd.Parameters.AddWithValue("@CAP", trasgressore.CAP);
                        cmd.Parameters.AddWithValue("@CodFisc", trasgressore.CodFisc);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the trasgressore", ex);
            }
        }

    }
}

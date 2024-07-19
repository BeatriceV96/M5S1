using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Services;

namespace EsercitazioneSettimanale1.DAO
{
    public class TrasgressoreDao : DaoBase, ITrasgressoreDao
    {
        private const string SELECT_ALL_TRASGRESSORI = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc FROM Anagrafica";

        public TrasgressoreDao(IConfiguration configuration, ILogger<TrasgressoreDao> logger) : base(configuration, logger) { }

        public IEnumerable<TrasgressoreEntity> GetAll()
        {
            var result = new List<TrasgressoreEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_TRASGRESSORI, conn))
                {
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new TrasgressoreEntity
                        {
                            IdAnagrafica = reader.GetInt32(0),
                            Cognome = reader.GetString(1),
                            Nome = reader.GetString(2),
                            Indirizzo = reader.GetString(3),
                            Citta = reader.GetString(4),
                            CAP = reader.GetString(5),
                            CodFisc = reader.GetString(6)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetAll));
                throw;
            }
            return result;
        }

        public TrasgressoreEntity GetById(int id)
        {
            TrasgressoreEntity trasgressore = null;
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand("SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc FROM Anagrafica WHERE IdAnagrafica = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        trasgressore = new TrasgressoreEntity
                        {
                            IdAnagrafica = reader.GetInt32(0),
                            Cognome = reader.GetString(1),
                            Nome = reader.GetString(2),
                            Indirizzo = reader.GetString(3),
                            Citta = reader.GetString(4),
                            CAP = reader.GetString(5),
                            CodFisc = reader.GetString(6)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetById));
                throw;
            }
            return trasgressore;
        }

        public TrasgressoreEntity Save(TrasgressoreEntity trasgressore)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc) OUTPUT INSERTED.IdAnagrafica VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @codFisc)", conn);
                cmd.Parameters.AddWithValue("@cognome", trasgressore.Cognome);
                cmd.Parameters.AddWithValue("@nome", trasgressore.Nome);
                cmd.Parameters.AddWithValue("@indirizzo", trasgressore.Indirizzo);
                cmd.Parameters.AddWithValue("@citta", trasgressore.Citta);
                cmd.Parameters.AddWithValue("@cap", trasgressore.CAP);
                cmd.Parameters.AddWithValue("@codFisc", trasgressore.CodFisc);
                trasgressore.IdAnagrafica = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(Save));
                throw;
            }
            return trasgressore;
        }
    }
}

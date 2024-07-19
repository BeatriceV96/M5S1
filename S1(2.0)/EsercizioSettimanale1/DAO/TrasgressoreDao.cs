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
        private const string SELECT_TRASGRESSORE_BY_ID = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc FROM Anagrafica WHERE IdAnagrafica = @id";
        private const string INSERT_TRASGRESSORE = "INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, Cod_Fisc) OUTPUT INSERTED.IdAnagrafica VALUES (@cognome, @nome, @indirizzo, @citta, @cap, @codFisc)";
        private const string UPDATE_TRASGRESSORE = "UPDATE Anagrafica SET Cognome = @cognome, Nome = @nome, Indirizzo = @indirizzo, Citta = @citta, CAP = @cap, Cod_Fisc = @codFisc WHERE IdAnagrafica = @id";
        private const string DELETE_TRASGRESSORE = "DELETE FROM Anagrafica WHERE IdAnagrafica = @id";

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

        public TrasgressoreEntity Create(TrasgressoreEntity trasgressore)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Citta, CAP, CodFisc) OUTPUT INSERTED.IdAnagrafica VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CodFisc)", conn))
                {
                    cmd.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", trasgressore.Nome);
                    cmd.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
                    cmd.Parameters.AddWithValue("@Citta", trasgressore.Citta);
                    cmd.Parameters.AddWithValue("@CAP", trasgressore.CAP);
                    cmd.Parameters.AddWithValue("@CodFisc", trasgressore.CodFisc);
                    trasgressore.IdAnagrafica = (int)cmd.ExecuteScalar();
                }
            }
            return trasgressore;
        }

        public TrasgressoreEntity Update(TrasgressoreEntity trasgressore)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("UPDATE Anagrafica SET Cognome = @Cognome, Nome = @Nome, Indirizzo = @Indirizzo, Citta = @Citta, CAP = @CAP, CodFisc = @CodFisc WHERE IdAnagrafica = @IdAnagrafica", conn))
                {
                    cmd.Parameters.AddWithValue("@IdAnagrafica", trasgressore.IdAnagrafica);
                    cmd.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
                    cmd.Parameters.AddWithValue("@Nome", trasgressore.Nome);
                    cmd.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
                    cmd.Parameters.AddWithValue("@Citta", trasgressore.Citta);
                    cmd.Parameters.AddWithValue("@CAP", trasgressore.CAP);
                    cmd.Parameters.AddWithValue("@CodFisc", trasgressore.CodFisc);
                    cmd.ExecuteNonQuery();
                }
            }
            return trasgressore;
        }

        public void Delete(int id)
            {
                try
                {
                    using var conn = new SqlConnection(connectionString);
                    conn.Open();
                    using var cmd = new SqlCommand(DELETE_TRASGRESSORE, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Exception in {}", nameof(Delete));
                    throw new Exception("An error occurred while deleting the trasgressore", ex);
                }
            }
        }
    }

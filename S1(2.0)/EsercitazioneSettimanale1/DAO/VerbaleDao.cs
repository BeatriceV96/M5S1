using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using EsercitazioneSettimanale1.Models.Interfaces;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Models.Services;

namespace EsercitazioneSettimanale1.DAO
{
    public class VerbaleDao : DaoBase, IVerbaleDao
    {
        public VerbaleDao(IConfiguration configuration, ILogger<VerbaleDao> logger) : base(configuration, logger) { }

        public void Save(VerbaleEntity verbale)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("INSERT INTO Verbale (IdAnagrafica, IdViolazione, DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti) VALUES (@idAnagrafica, @idViolazione, @dataViolazione, @indirizzoViolazione, @nominativoAgente, @dataTrascrizioneVerbale, @importo, @decurtamentoPunti)", conn);
                cmd.Parameters.AddWithValue("@idAnagrafica", verbale.IdAnagrafica);
                cmd.Parameters.AddWithValue("@idViolazione", verbale.IdViolazione);
                cmd.Parameters.AddWithValue("@dataViolazione", verbale.DataViolazione);
                cmd.Parameters.AddWithValue("@indirizzoViolazione", verbale.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@nominativoAgente", verbale.Nominativo_Agente);
                cmd.Parameters.AddWithValue("@dataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                cmd.Parameters.AddWithValue("@importo", verbale.Importo);
                cmd.Parameters.AddWithValue("@decurtamentoPunti", verbale.DecurtamentoPunti);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(Save));
                throw;
            }
        }

        public IEnumerable<VerbaleEntity> GetByTrasgressoreId(int idAnagrafica)
        {
            var result = new List<VerbaleEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("SELECT * FROM Verbale WHERE IdAnagrafica = @idAnagrafica", conn);
                cmd.Parameters.AddWithValue("@idAnagrafica", idAnagrafica);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new VerbaleEntity
                    {
                        IdVerbale = reader.GetInt32(0),
                        IdAnagrafica = reader.GetInt32(1),
                        IdViolazione = reader.GetInt32(2),
                        DataViolazione = reader.GetDateTime(3),
                        IndirizzoViolazione = reader.GetString(4),
                        Nominativo_Agente = reader.GetString(5),
                        DataTrascrizioneVerbale = reader.GetDateTime(6),
                        Importo = reader.GetDecimal(7),
                        DecurtamentoPunti = reader.GetInt32(8)
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetByTrasgressoreId));
                throw;
            }
            return result;
        }

        public IEnumerable<VerbaleEntity> GetVerbaliPerTrasgressore()
        {
            var result = new List<VerbaleEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("SELECT a.Cognome, a.Nome, COUNT(v.IdVerbale) AS NumeroVerbali FROM Verbale v JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica GROUP BY a.Cognome, a.Nome", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new VerbaleEntity
                    {
                        Cognome = reader.GetString(0),
                        Nome = reader.GetString(1),
                        NumeroVerbali = reader.GetInt32(2)
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetVerbaliPerTrasgressore));
                throw;
            }
            return result;
        }

        public IEnumerable<VerbaleEntity> GetPuntiPerTrasgressore()
        {
            var result = new List<VerbaleEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("SELECT a.Cognome, a.Nome, SUM(v.DecurtamentoPunti) AS PuntiDecurtati FROM Verbale v JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica GROUP BY a.Cognome, a.Nome", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new VerbaleEntity
                    {
                        Cognome = reader.GetString(0),
                        Nome = reader.GetString(1),
                        PuntiDecurtati = reader.GetInt32(2)
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetPuntiPerTrasgressore));
                throw;
            }
            return result;
        }

        public IEnumerable<VerbaleEntity> GetViolazioniOltre10Punti()
        {
            var result = new List<VerbaleEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("SELECT a.Cognome, a.Nome, v.DataViolazione, v.IndirizzoViolazione, v.Importo, v.DecurtamentoPunti FROM Verbale v JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica WHERE v.DecurtamentoPunti > 10", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new VerbaleEntity
                    {
                        Cognome = reader.GetString(0),
                        Nome = reader.GetString(1),
                        DataViolazione = reader.GetDateTime(2),
                        IndirizzoViolazione = reader.GetString(3),
                        Importo = reader.GetDecimal(4),
                        DecurtamentoPunti = reader.GetInt32(5)
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetViolazioniOltre10Punti));
                throw;
            }
            return result;
        }

        public IEnumerable<VerbaleEntity> GetViolazioniOltre400Euro()
        {
            var result = new List<VerbaleEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var cmd = new SqlCommand("SELECT a.Cognome, a.Nome, v.DataViolazione, v.IndirizzoViolazione, v.Importo, v.DecurtamentoPunti FROM Verbale v JOIN Anagrafica a ON v.IdAnagrafica = a.IdAnagrafica WHERE v.Importo > 400", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new VerbaleEntity
                    {
                        Cognome = reader.GetString(0),
                        Nome = reader.GetString(1),
                        DataViolazione = reader.GetDateTime(2),
                        IndirizzoViolazione = reader.GetString(3),
                        Importo = reader.GetDecimal(4),
                        DecurtamentoPunti = reader.GetInt32(5)
                    });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Exception in {}", nameof(GetViolazioniOltre400Euro));
                throw;
            }
            return result;
        }
    }
}

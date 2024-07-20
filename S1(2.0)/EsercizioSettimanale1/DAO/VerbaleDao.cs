using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;

using EsercitazioneSettimanale1.Models;


namespace EsercitazioneSettimanale1.DAO
{
    public class VerbaleDao : DaoBase
    {
        public VerbaleDao(IConfiguration configuration, ILogger<VerbaleDao> logger) : base(configuration, logger) { }



        public List<VerbaleEntity> GetVerbali()
        {
            List<VerbaleEntity> result = new List<VerbaleEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string SELECT_ALL_VERBALI = @"
                SELECT v.IdVerbale, 
                       a.IdAnagrafica, 
                       a.Nome, 
                       a.Cognome, 
                       v.IdViolazione, 
                       t.Descrizione, 
                       v.DataViolazione, 
                       v.IndirizzoViolazione, 
                       v.Nominativo_Agente, 
                       v.DataTrascrizioneVerbale, 
                       v.Importo, 
                       v.DecurtamentoPunti 
                FROM Verbale AS v 
                INNER JOIN Anagrafica AS a ON a.IdAnagrafica = v.IdAnagrafica 
                INNER JOIN TipoViolazione AS t ON t.IdViolazione = v.IdViolazione";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_VERBALI, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleEntity verbale = new VerbaleEntity
                                {
                                    IdVerbale = reader.GetInt32(0),
                                    IdAnagrafica = reader.GetInt32(1),
                                    Nome = reader.GetString(2),
                                    Cognome = reader.GetString(3),
                                    IdViolazione = reader.GetInt32(4),
                                    Descrizione = reader.GetString(5),
                                    DataViolazione = reader.GetDateTime(6),
                                    IndirizzoViolazione = reader.GetString(7),
                                    Nominativo_Agente = reader.GetString(8),
                                    DataTrascrizioneVerbale = reader.GetDateTime(9),
                                    Importo = reader.GetDecimal(10),
                                    DecurtamentoPunti = reader.GetInt32(11)
                                };
                                result.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the verbali", ex);
            }
            return result;
        }

        public void CreateVerbale(VerbaleEntity verbale)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string INSERT_VERBALE = "insert into Verbale (IdAnagrafica,IdViolazione,DataViolazione,IndirizzoViolazione,Nominativo_Agente,DataTrascrizioneVerbale,Importo,DecurtamentoPunti) values (@IdAnagrafica,@IdViolazione,@DataViolazione,@IndirizzoViolazione,@Nominativo_Agente,@DataTrascrizioneVerbale,@Importo,@DecurtamentoPunti)";
                    {
                        using (SqlCommand cmd = new SqlCommand(INSERT_VERBALE, conn))
                        {
                            cmd.Parameters.AddWithValue("@IdAnagrafica", verbale.IdAnagrafica);
                            cmd.Parameters.AddWithValue("@IdViolazione", verbale.IdViolazione);
                            cmd.Parameters.AddWithValue("@DataViolazione", verbale.DataViolazione);
                            cmd.Parameters.AddWithValue("@IndirizzoViolazione", verbale.IndirizzoViolazione);
                            cmd.Parameters.AddWithValue("@Nominativo_Agente", verbale.Nominativo_Agente);
                            cmd.Parameters.AddWithValue("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale);
                            cmd.Parameters.AddWithValue("@Importo", verbale.Importo);
                            cmd.Parameters.AddWithValue("@DecurtamentoPunti", verbale.DecurtamentoPunti);                           
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the verbale", ex);
            }
        }       

        public List<TrasgressoreEntity> GetTrasgressori()
            {
            List<TrasgressoreEntity> result = new List<TrasgressoreEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    const string SELECT_ALL_TRASGRESSORI = "SELECT * FROM Anagrafica";
                    using (SqlCommand cmd = new SqlCommand(SELECT_ALL_TRASGRESSORI, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TrasgressoreEntity trasgressore = new TrasgressoreEntity
                                {
                                    IdAnagrafica = reader.GetInt32(0),
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
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the trasgressori", ex);
            }
            return result;
        }
    }
}

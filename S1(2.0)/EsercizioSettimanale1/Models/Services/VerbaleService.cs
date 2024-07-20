using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.DAO;
using System.Data.SqlClient;

namespace EsercitazioneSettimanale1.Services
{
    public class VerbaleService
    {
        private readonly VerbaleDao verbaleDao;
        private readonly IConfiguration configuration;

        public VerbaleService(VerbaleDao verbaleDao, IConfiguration configuration)
        {
            this.verbaleDao = verbaleDao;
            this.configuration = configuration;
        }

        public List<VerbaleEntity> GetVerbali()
        {
            return verbaleDao.GetVerbali();

        }

        public void CreateVerbale(VerbaleEntity verbale)
        {
            verbaleDao.CreateVerbale(verbale);
        }

        public List<TrasgressoreEntity> GetTrasgressori()
        {
            return verbaleDao.GetTrasgressori();
        }

        public List<VerbaleEntity> GetVerbaliPerTrasgressore()
        {
            List<VerbaleEntity> verbali = new List<VerbaleEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select a.Nome,a.Cognome, COUNT(v.IdVerbale) as TotaleVerbali from Verbale as v inner join Anagrafica as a on a.IdAnagrafica = v.IdAnagrafica group by a.Nome, a.Cognome", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleEntity verbale = new VerbaleEntity
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    TotaleVerbali = reader.GetInt32(2)
                                };
                                verbali.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the verbali", ex);
            }
            return verbali;
        }

        public List<VerbaleEntity> GetViolazioniOltre10Punti()
        {
            List<VerbaleEntity> verbali = new List<VerbaleEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select a.Nome,a.Cognome, v.Importo, v.DataViolazione,v.DecurtamentoPunti from Verbale as v inner join Anagrafica as a on a.IdAnagrafica = v.IdAnagrafica where v.DecurtamentoPunti > 10\r\n", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleEntity verbale = new VerbaleEntity
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    Importo = reader.GetDecimal(2),
                                    DataViolazione = reader.GetDateTime(3),
                                    DecurtamentoPunti = reader.GetInt32(4)
                                };
                                verbali.Add(verbale);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the verbali", ex);
            }
            return verbali;
        }


        public List<VerbaleEntity> GetTotalePunti()
        {
            List<VerbaleEntity> verbali = new List<VerbaleEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select a.Nome,a.Cognome, SUM(v.DecurtamentoPunti) as TotalePunti from Verbale as v inner join Anagrafica as a on a.IdAnagrafica = v.IdAnagrafica group by a.Nome, a.Cognome", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleEntity verbale = new VerbaleEntity
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    DecurtamentoPunti = reader.GetInt32(2)
                                };
                                verbali.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the verbali", ex);
            }
            return verbali;
        }

        public List<VerbaleEntity> GetVerbaliOltre400Euro()
        {
            List<VerbaleEntity> verbali = new List<VerbaleEntity>();
            try
            {
                using (SqlConnection conn = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("select a.Nome,a.Cognome, v.Importo from Verbale as v inner join Anagrafica as a on a.IdAnagrafica = v.IdAnagrafica where v.Importo > 400", conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                VerbaleEntity verbale = new VerbaleEntity
                                {
                                    Nome = reader.GetString(0),
                                    Cognome = reader.GetString(1),
                                    Importo = reader.GetDecimal(2)
                                };
                                verbali.Add(verbale);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting the verbali", ex);
            }
            return verbali;
    }
} 
}

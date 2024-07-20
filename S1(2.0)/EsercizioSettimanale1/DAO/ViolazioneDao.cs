using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data.SqlClient;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Services;


namespace EsercitazioneSettimanale1.DAO
{
    public class ViolazioneDao : DaoBase
    {
        private const string SELECT_ALL_VIOLAZIONI = "SELECT IdViolazione, Descrizione, Importo FROM TipoViolazione";

        public ViolazioneDao(IConfiguration configuration, ILogger<ViolazioneDao> logger) : base(configuration, logger) { }

        public IEnumerable<ViolazioneEntity> GetAll()
        {
            var result = new List<ViolazioneEntity>();
            try
            {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_VIOLAZIONI, conn))
                {
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new ViolazioneEntity
                        {
                            IdViolazione = reader.GetInt32(0),
                            Descrizione = reader.GetString(1),
                            Importo = reader.GetDecimal(2)
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
    }
}

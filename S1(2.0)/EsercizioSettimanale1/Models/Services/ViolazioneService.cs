using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.DAO;

namespace EsercitazioneSettimanale1.Services
{
    public class ViolazioneService 
    {
        private readonly ViolazioneDao violazioneDao;

        public ViolazioneService(ViolazioneDao violazioneDao)
        {
            this.violazioneDao = violazioneDao;
        }

        public IEnumerable<ViolazioneEntity> GetAll()
        {
            return violazioneDao.GetAll();
        }
    }
}

using System.Collections.Generic;
using EsercitazioneSettimanale1.Models;
using EsercitazioneSettimanale1.Models.Services;

namespace EsercitazioneSettimanale1.Services
{
    public class ViolazioneService 
    {
        private readonly IViolazioneDao violazioneDao;

        public ViolazioneService(IViolazioneDao violazioneDao)
        {
            this.violazioneDao = violazioneDao;
        }

        public IEnumerable<ViolazioneEntity> GetAll()
        {
            return violazioneDao.GetAll();
        }
    }
}

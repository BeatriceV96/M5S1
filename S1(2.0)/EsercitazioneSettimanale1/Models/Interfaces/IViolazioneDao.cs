namespace EsercitazioneSettimanale1.Models.Services
{
    public interface IViolazioneDao
    {
        IEnumerable<ViolazioneEntity> GetAll();
    }
}

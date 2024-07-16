using DeliveryService.DataLayer.Entities;

namespace DeliveryService.DataLayer.Interfaces
{

    public interface ISpedizioneService
    {
        IEnumerable<Spedizione> GetAllSpedizioni();
        Spedizione GetSpedizioneById(int id);
        void AddSpedizione(Spedizione spedizione);
        void UpdateSpedizione(Spedizione spedizione);
        void DeleteSpedizione(int id);
    }
}

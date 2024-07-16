using DeliveryService.DataLayer.Interfaces;
using DeliveryService.DataLayer.Entities;



namespace DeliveryService.DataLayer.Services
{
    public class SpedizioneService : ISpedizioneService
    {
        private readonly IRepository<Spedizione> _repository;

       public SpedizioneService(IRepository<Spedizione> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Spedizione> GetAllSpedizioni()
        {
            return _repository.GetAll();
        }

        public Spedizione GetSpedizioneById(int id)
        {
            return _repository.GetById(id);
        }

        public void AddSpedizione(Spedizione spedizione)
        {
            _repository.Add(spedizione);
        }

        public void UpdateSpedizione(Spedizione spedizione)
        {
            _repository.Update(spedizione);
        }

        public void DeleteSpedizione(int id)
        {
            _repository.Delete(id);
        }
    }
}

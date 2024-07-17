using DeliveryService.DataLayer.Interfaces;

namespace DeliveryService.DataLayer
{
    public class DbContext 
    {
        public IClienteDao Clienti { get; set; }
        public ISpedizioneDao Spedizioni { get; set; }

        public DbContext(IClienteDao clienteDao, ISpedizioneDao spedizioneDao)
        {
            Clienti = clienteDao;
            Spedizioni = spedizioneDao;
        }
    }
}

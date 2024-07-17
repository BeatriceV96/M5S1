using DeliveryService.DataLayer.Entities;
using System.Collections.Generic;

namespace DeliveryService.DataLayer.Interfaces
{
    public interface IClienteDao
    {
        /// <summary>
        /// Crea un cliente.
        /// </summary>
        /// <param name="cliente">Dettagli del cliente.</param>
        void Create(Cliente cliente);

        /// <summary>
        /// Elimina un cliente.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        void Delete(int id);

        /// <summary>
        /// Recupera i dati di un cliente.
        /// </summary>
        /// <param name="id">ID del cliente.</param>
        Cliente Read(int id);

        /// <summary>
        /// Aggiorna i dati di un cliente.
        /// </summary>
        /// <param name="cliente">Dettagli aggiornati del cliente.</param>
        void Update(Cliente cliente);

        /// <summary>
        /// Recupera tutti i clienti.
        /// </summary>
        List<Cliente> ReadAll();
    }
}

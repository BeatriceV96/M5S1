using DeliveryService.DataLayer.Entities;
using DeliveryService.DataLayer.Interfaces;
using System.Collections.Generic;

namespace DeliveryService.DataLayer.Services
{
    public class ClienteService 
    {
        private readonly List<Cliente> _clienti = new List<Cliente>();

        public void Create(Cliente cliente)
        {
            cliente.Id = _clienti.Count + 1;
            _clienti.Add(cliente);
        }

        public void Delete(int id)
        {
            var cliente = _clienti.FirstOrDefault(c => c.Id == id);
            if (cliente != null)
            {
                _clienti.Remove(cliente);
            }
        }

        public Cliente Read(int id)
        {
            return _clienti.FirstOrDefault(c => c.Id == id);
        }

        public void Update(Cliente cliente)
        {
            var existingCliente = _clienti.FirstOrDefault(c => c.Id == cliente.Id);
            if (existingCliente != null)
            {
                existingCliente.Nome = cliente.Nome;
                existingCliente.TipoCliente = cliente.TipoCliente;
                existingCliente.CodiceFiscale = cliente.CodiceFiscale;
                existingCliente.PartitaIVA = cliente.PartitaIVA;
            }
        }

        public List<Cliente> ReadAll()
        {
            return _clienti;
        }
    }
}

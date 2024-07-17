using DeliveryService.DataLayer;
using DeliveryService.DataLayer.Entities;
using DeliveryService.DataLayer.Interfaces;

public class ClienteService
{
    private readonly DbContext _dbContext;

    public ClienteService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateCliente(Cliente cliente)
    {
        _dbContext.Clienti.Create(cliente);
    }

    public Cliente GetClienteById(int id)
    {
        return _dbContext.Clienti.Read(id);
    }

    public List<Cliente> GetAllClienti()
    {
        return _dbContext.Clienti.ReadAll();
    }

    public void UpdateCliente(Cliente cliente)
    {
        _dbContext.Clienti.Update(cliente);
    }

    public void DeleteCliente(int id)
    {
        _dbContext.Clienti.Delete(id);
    }
}

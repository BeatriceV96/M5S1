using DeliveryService.DataLayer;
using DeliveryService.DataLayer.Entities;
using DeliveryService.DataLayer.Interfaces;
using System.Collections.Generic;

public class SpedizioneService 
{
    private readonly DbContext _dbContext;

    public SpedizioneService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateSpedizione(Spedizione spedizione)
    {
        _dbContext.Spedizioni.Create(spedizione);
    }

    public Spedizione GetSpedizioneById(int id)
    {
        return _dbContext.Spedizioni.Read(id);
    }

    public List<Spedizione> GetAllSpedizioni()
    {
        return _dbContext.Spedizioni.ReadAll();
    }

    public void UpdateSpedizione(Spedizione spedizione)
    {
        _dbContext.Spedizioni.Update(spedizione);
    }

    public void DeleteSpedizione(int id)
    {
        _dbContext.Spedizioni.Delete(id);
    }

    public List<AggiornamentoSpedizione> GetAggiornamentiSpedizione(string codiceFiscalePartitaIVA, string numeroSpedizione)
    {
        return _dbContext.Spedizioni.GetAggiornamenti(codiceFiscalePartitaIVA, numeroSpedizione);
    }

    public List<Spedizione> GetSpedizioniInConsegnaOggi()
    {
        return _dbContext.Spedizioni.GetInConsegnaOggi();
    }

    public List<Spedizione> GetSpedizioniInAttesaDiConsegna()
    {
        return _dbContext.Spedizioni.GetInAttesaDiConsegna();
    }

    public Dictionary<string, int> GetSpedizioniRaggruppatePerCitta()
    {
        return _dbContext.Spedizioni.GetRaggruppatePerCitta();
    }

    public void Create(Spedizione spedizione)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Spedizione Read(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Spedizione spedizione)
    {
        throw new NotImplementedException();
    }

    public List<Spedizione> ReadAll()
    {
        throw new NotImplementedException();
    }

    public List<AggiornamentoSpedizione> GetAggiornamenti(string codiceFiscalePartitaIVA, string numeroSpedizione)
    {
        throw new NotImplementedException();
    }

    public List<Spedizione> GetInConsegnaOggi()
    {
        throw new NotImplementedException();
    }

    public List<Spedizione> GetInAttesaDiConsegna()
    {
        throw new NotImplementedException();
    }

    public Dictionary<string, int> GetRaggruppatePerCitta()
    {
        throw new NotImplementedException();
    }
}

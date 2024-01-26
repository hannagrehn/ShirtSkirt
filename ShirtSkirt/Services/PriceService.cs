
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class PriceService
{
    private readonly PriceRepo _priceRepo;

    public PriceService(PriceRepo priceRepo)
    {
        _priceRepo = priceRepo;
    }

    public PricelistEntity CreatePrice(decimal price)
    {
        var pricelistEntity = _priceRepo.GetOne(x => x.Price == price);
        pricelistEntity ??= _priceRepo.Create(new PricelistEntity { Price = price });
        return pricelistEntity;
    }


    public PricelistEntity GetPriceByValue(decimal price)
    {
        var pricelistEntity = _priceRepo.GetOne(x => x.Price == price);
        return pricelistEntity;
    }


    public PricelistEntity GetPriceById(int id)
    {
        var pricelistEntity = _priceRepo.GetOne(x => x.PriceId == id);
        return pricelistEntity;
    }

    public IEnumerable<PricelistEntity> GetPrices()
    {
        var prices = _priceRepo.GetAll();
        return prices;
    }

    public PricelistEntity UpdatePrice(PricelistEntity pricelistEntity)
    {
        var updatedPricelistEntity = _priceRepo.Update(x => x.PriceId == pricelistEntity.PriceId, pricelistEntity);
        return updatedPricelistEntity;
    }

    public bool DeletePrice(int id)
    {
        try
        {
            return _priceRepo.Delete(x => x.PriceId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

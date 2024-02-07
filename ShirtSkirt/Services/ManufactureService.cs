
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class ManufactureService
{
    private readonly ManufactureRepo _manufactureRepo;

    public ManufactureService(ManufactureRepo ManufactureRepo)
    {
        _manufactureRepo = ManufactureRepo;
    }

    public ManufactureEntity CreateManufacture(string manufactureName)
    {
        var manufactureEntity = _manufactureRepo.GetOne(x => x.ManufactureName == manufactureName);
        manufactureEntity ??= _manufactureRepo.Create(new ManufactureEntity { ManufactureName = manufactureName });
        return manufactureEntity;
    }

    public ManufactureEntity GetManufactureByName(string manufactureName)
    {
        var manufactureEntity = _manufactureRepo.GetOne(x => x.ManufactureName == manufactureName);
        return manufactureEntity;
    }

    public ManufactureEntity GetManufactureById(int id)
    {
        var manufactureEntity = _manufactureRepo.GetOne(x => x.ManufactureId == id);
        return manufactureEntity;
    }

    public IEnumerable<ManufactureEntity> GetManufacture()
    {
        var manufacturers = _manufactureRepo.GetAll();
        return manufacturers;
    }

    public ManufactureEntity UpdateManufacture(ManufactureEntity manufactureEntity)
    {
        var updatedManufactureEntity = _manufactureRepo.Update(x => x.ManufactureId == manufactureEntity.ManufactureId, manufactureEntity);
        return updatedManufactureEntity;
    }

    public bool DeleteManufacture(int id)
    {
        try
        {
            return _manufactureRepo.Delete(x => x.ManufactureId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

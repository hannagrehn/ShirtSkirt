

using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class AllianceService
{
    private readonly AllianceRepo _allianceRepo;

    public AllianceService(AllianceRepo AllianceRepo)
    {
        _allianceRepo = AllianceRepo;
    }

    public AllianceEntity CreateAlliance(string allianceName)
    {
        var allianceEntity = _allianceRepo.GetOne(x => x.AllianceName == allianceName);
        allianceEntity ??= _allianceRepo.Create(new AllianceEntity { AllianceName= allianceName });
        return allianceEntity;
    }

    public AllianceEntity GetAllianceByName(string allianceName)
    {
        var allianceEntity = _allianceRepo.GetOne(x => x.AllianceName == allianceName);
        return allianceEntity;
    }

    public AllianceEntity GetAllianceById(int id)
    {
        var allianceEntity = _allianceRepo.GetOne(x => x.AllianceId == id);
        return allianceEntity;
    }

    public IEnumerable<AllianceEntity> GetAlliance()
    {
        var alliances = _allianceRepo.GetAll();
        return alliances;
    }

    public AllianceEntity UpdateAlliance(AllianceEntity allianceEntity)
    {
        var updatedAllianceEntity = _allianceRepo.Update(x => x.AllianceId == allianceEntity.AllianceId, allianceEntity);
        return updatedAllianceEntity;
    }

    public bool DeleteAlliance(int id)
    {
        try
        {
            return _allianceRepo.Delete(x => x.AllianceId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

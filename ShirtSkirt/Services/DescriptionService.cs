using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;


namespace ShirtSkirt.Services;

//Allt här kanske är år helvete

public class DescriptionService
{
    private readonly DescriptionRepo _descriptionRepo;

    public DescriptionService(DescriptionRepo descriptionRepo)
    {
        _descriptionRepo = descriptionRepo;
    }

    public DescriptionEntity CreateDescription(string ingress, string longDescription)
    {
        var descriptionEntity = _descriptionRepo.GetOne(x => x.Ingress == ingress && x.LongDescription == longDescription);
        descriptionEntity ??= _descriptionRepo.Create(new DescriptionEntity { Ingress = ingress, LongDescription = longDescription });
        return descriptionEntity;
    }

    public DescriptionEntity GetDescriptionByIngress(string Ingress)
    {
        var DescriptionEntity = _descriptionRepo.GetOne(x => x.Ingress == Ingress);
        return DescriptionEntity;
    }


    public DescriptionEntity GetDescriptionById(int id)
    {
        var DescriptionEntity = _descriptionRepo.GetOne(x => x.DescriptionId == id);
        return DescriptionEntity;
    }

    public IEnumerable<DescriptionEntity> GetDescriptions()
    {
        var descriptions = _descriptionRepo.GetAll();
        return descriptions;
    }

    public DescriptionEntity UpdateDescription(DescriptionEntity descriptionEntity)
    {
        var updatedDescriptionEntity = _descriptionRepo.Update(x => x.DescriptionId == descriptionEntity.DescriptionId, descriptionEntity);
        return updatedDescriptionEntity;
    }

    public bool DeleteDescription(int id)
    {
        try
        {
            return _descriptionRepo.Delete(x => x.DescriptionId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return false;
        }
    }
}

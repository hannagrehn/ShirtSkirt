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


    public DescriptionEntity CreateCategory(string Ingress)
    {
        var DescriptionEntity = _descriptionRepo.GetOne(x => x.Ingress == Ingress);
        DescriptionEntity ??= _descriptionRepo.Create(new DescriptionEntity { Ingress = Ingress });
        return DescriptionEntity;
    }

    public DescriptionEntity GetCategoryByName(string Ingress)
    {
        var DescriptionEntity = _descriptionRepo.GetOne(x => x.Ingress == Ingress);
        return DescriptionEntity;
    }

    public DescriptionEntity GetCategoryById(int id)
    {
        var DescriptionEntity = _descriptionRepo.GetOne(x => x.DescriptionId == id);
        return DescriptionEntity;
    }

    public IEnumerable<DescriptionEntity> GetCategories()
    {
        var categories = _descriptionRepo.GetAll();
        return categories;
    }

    public DescriptionEntity UpdateCategory(DescriptionEntity DescriptionEntity)
    {
        var updatedDescriptionEntity = _descriptionRepo.Update(x => x.DescriptionId == DescriptionEntity.DescriptionId, DescriptionEntity);
        return updatedDescriptionEntity;
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            return _descriptionRepo.Delete(x => x.DescriptionId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

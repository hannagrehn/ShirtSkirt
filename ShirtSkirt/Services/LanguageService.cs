using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class LanguageService
{
    private readonly LanguageRepo _languageRepo;

    public LanguageService(LanguageRepo languageRepo)
    {
        _languageRepo = languageRepo;
    }

    public LanguageEntity CreateLanguage(string language)
    {      
        try
        {
            var languageEntity = _languageRepo.GetOne(x => x.LanguageName == language);
            languageEntity ??= _languageRepo.Create(new LanguageEntity { LanguageName = language });
            return languageEntity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return null!;
        }
    }

    public LanguageEntity GetLanguageByName(string language)
    {
        var languageEntity = _languageRepo.GetOne(x => x.LanguageName == language);
        return languageEntity;
    }

    public LanguageEntity GetLanguageById(int id)
    {
        var languageEntity = _languageRepo.GetOne(x => x.LanguageId == id);
        return languageEntity;
    }

    public IEnumerable<LanguageEntity> GetLanguage()
    {
        var languagers = _languageRepo.GetAll();
        return languagers;
    }

    public LanguageEntity UpdateLanguage(LanguageEntity languageEntity)
    {
        var updatedLanguageEntity = _languageRepo.Update(x => x.LanguageId == languageEntity.LanguageId, languageEntity);
        return updatedLanguageEntity;
    }

    public bool DeleteLanguage(int id)
    {
        try
        {
            return _languageRepo.Delete(x => x.LanguageId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

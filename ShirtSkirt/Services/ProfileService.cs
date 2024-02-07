using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class ProfileService(ProfileRepo profileRepo, AllianceService allianceService, LanguageService languageService, RoleService roleService)
{
    private readonly ProfileRepo _profileRepo = profileRepo;

    private readonly AllianceService _allianceService = allianceService;
    private readonly LanguageService _languageService = languageService;
    private readonly RoleService _roleService = roleService;



    public ProfileEntity CreateProfile(
        int profileId,
        string firstName,
        string lastName,
        string allianceName,
        string languageName,
        string roleName)
    {
        try
        {
            var allianceEntity = _allianceService.CreateAlliance(allianceName);
            var languageEntity = _languageService.CreateLanguage(languageName);
            var roleEntity = _roleService.CreateRole(roleName);

            if (allianceEntity != null && languageEntity != null && roleEntity != null) 
            {
                var profileEntity = new ProfileEntity
                {
                    ProfileId = profileId,
                    FirstName = firstName,
                    LastName = lastName,
                    AllianceId = allianceEntity.AllianceId,
                    LanguageId = languageEntity.LanguageId,
                    RoleId = roleEntity.RoleId,
                };

                if (_profileRepo != null)
                {
                    profileEntity = _profileRepo.Create(profileEntity);
                    return profileEntity;
                }
                else
                {
                    Debug.WriteLine("Error :: _profileRepo is null.");
                }
            }
            else
            {
                Debug.WriteLine("Error :: One or more entities are null.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
        return null!;
    }

    public ProfileEntity GetProfileByLastName(string lastName)
    {
        Console.WriteLine($"Searching for profile with lastname: {lastName}");

        var profileEntity = _profileRepo.GetOne(x => x.LastName == lastName);

        if (profileEntity != null)
        {
            Console.WriteLine($"Profile found - {profileEntity.FirstName} {profileEntity.LastName}, {profileEntity.Role} in {profileEntity.Alliance}.");
        }
        else
        {
            Console.WriteLine("No profile found.");
        }
        return profileEntity!;
    }


    public IEnumerable<ProfileEntity> GetProfiles()
    {
        var profiles = _profileRepo.GetAll();
        try
        {
            return profiles;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return null!;
        }
    }

    public IEnumerable<ProfileEntity> GetProfilesWithAlliances()
    {
        var profiles = _profileRepo.GetAll();
        try
        {
            return profiles;
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return null!;
        }
    }





    public ProfileEntity UpdateProfile(ProfileEntity profileEntity)
    {
        var updatedProfileEntity = _profileRepo.Update(x => x.LastName == profileEntity.LastName, profileEntity);
        return updatedProfileEntity;
    }

    public bool DeleteProfile(string lastName)
    {
        try
        {
            return _profileRepo.Delete(x => x.LastName == lastName);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return false;
        }
    }
}

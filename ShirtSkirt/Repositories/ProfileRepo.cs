using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Entities;
using System.Diagnostics;
using System.Linq.Expressions;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class ProfileRepo : BaseRepo<ProfileEntity>
{
    private readonly AppContext _appContext;

    public ProfileRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }

    public override ProfileEntity GetOne(Expression<Func<ProfileEntity, bool>> predicate)
    {
        try
        {
            var profile = _appContext.Profiles
                .Include(i => i.Alliance)
                .Include(i => i.Language)
                .Include(i => i.Role)
                .Where(predicate);

            return profile.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            throw;
        }

    }

    public override IEnumerable<ProfileEntity> GetAll()
    {
        try
        {
            return _appContext.Profiles
           .Include(i => i.Alliance)
           .Include(i => i.Language)
           .Include(i => i.Role)
           .ToList();

        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            throw;
        }
    }

}

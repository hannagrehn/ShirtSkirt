using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class ProfileRepo : BaseRepo<ProfileEntity>
{
    private readonly AppContext _appContext;

    public ProfileRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }
}

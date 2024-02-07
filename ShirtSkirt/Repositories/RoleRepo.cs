using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class RoleRepo : BaseRepo<RoleEntity>
{
    private readonly AppContext _appContext;

    public RoleRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }
}

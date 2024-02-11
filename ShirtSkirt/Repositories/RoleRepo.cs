using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Diagnostics;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class RoleRepo : BaseRepo<RoleEntity>
{
    private readonly AppContext _appContext;

    public RoleRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }

    public async Task<RoleEntity> CreateAsync(RoleEntity roleEntity)
    {
        try
        {
            _appContext.Roles.Add(roleEntity);
            await _appContext.SaveChangesAsync();

            return roleEntity;

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }
}

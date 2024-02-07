using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class AllianceRepo : BaseRepo<AllianceEntity>
{
    private readonly AppContext _appContext;

    public AllianceRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }
}

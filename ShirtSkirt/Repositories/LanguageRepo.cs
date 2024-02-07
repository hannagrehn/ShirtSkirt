using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class LanguageRepo : BaseRepo<LanguageEntity>
{
    private readonly AppContext _appContext;

    public LanguageRepo(AppContext appContext) : base(appContext)
    {
        _appContext = appContext;
    }
}

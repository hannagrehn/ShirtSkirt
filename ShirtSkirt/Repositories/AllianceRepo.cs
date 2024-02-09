using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using AppContext = ShirtSkirt.Contexts.AppContext;

namespace ShirtSkirt.Repositories;

public class AllianceRepo(AppContext appContext) : BaseRepo<AllianceEntity>(appContext)
{
    private readonly AppContext _appContext = appContext;
}

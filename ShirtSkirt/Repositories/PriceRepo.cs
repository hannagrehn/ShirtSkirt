
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Repositories;

public class PriceRepo(DataContext context) : BaseRepo<PricelistEntity>(context)
{
    private readonly DataContext _context = context;
}

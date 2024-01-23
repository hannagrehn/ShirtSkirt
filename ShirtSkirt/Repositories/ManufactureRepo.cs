
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Repositories;

public class ManufactureRepo(DataContext context) : BaseRepo<ManufactureEntity>(context)
{

    private readonly DataContext _context = context;
}

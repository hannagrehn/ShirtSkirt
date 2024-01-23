
using ShirtSkirt.Entities;
using ShirtSkirt.Contexts;

namespace ShirtSkirt.Repositories;

public class DescriptionRepo(DataContext context) : BaseRepo<DescriptionEntity>(context)
{
    private readonly DataContext _context = context;
}

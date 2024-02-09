using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Repositories;

public class CategoryRepo(DataContext context) : BaseRepo<CategoryEntity>(context)
{
    private readonly DataContext _context = context;
}

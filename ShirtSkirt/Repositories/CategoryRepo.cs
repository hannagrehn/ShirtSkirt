
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Linq.Expressions;

namespace ShirtSkirt.Repositories;

public class CategoryRepo(DataContext context) : BaseRepo<CategoryEntity>(context)
{
    private readonly DataContext _context = context;
}



using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;

namespace ShirtSkirt.Repositories;

public class ReviewRepo(DataContext context) : BaseRepo<ReviewEntity>(context)
{
    private readonly DataContext _context = context;
}

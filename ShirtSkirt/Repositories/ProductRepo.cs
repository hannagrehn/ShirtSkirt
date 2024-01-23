
using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace ShirtSkirt.Repositories;

public class ProductRepo(DataContext context) : BaseRepo<ProductEntity>(context)
{
    private readonly DataContext _context = context;

    public override IEnumerable<ProductEntity> GetAll()
    {
        try
        {
            return _context.Products.Include(x => x.Categories).ToList();
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return _context.Products.Include(x => x.Categories).FirstOrDefault(predicate, null!);
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }
}

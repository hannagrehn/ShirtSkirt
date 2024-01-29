using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
namespace ShirtSkirt.Repositories;

public class ProductRepo(DataContext context) : BaseRepo<ProductEntity>(context)
{
    private readonly DataContext _context;


    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            return _context.Products
            .Include(i => i.ManufactureName)
            .Include(i => i.Ingress)
            .Include(i => i.ReviewText)
            .Include(i => i.Price)
            .Include(i => i.CategoryName)
            .FirstOrDefault(predicate, null!);
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }

        return null!;
    }    
    
    public override IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products
            .Include(i => i.ManufactureName)
            .Include(i => i.Ingress)
            .Include(i => i.ReviewText)
            .Include(i => i.Price)
            .Include(i => i.CategoryName)
            .ToList();
    }
}


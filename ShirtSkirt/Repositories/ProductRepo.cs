using Microsoft.EntityFrameworkCore;
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Diagnostics;
using System.Linq.Expressions;

namespace ShirtSkirt.Repositories;

public class ProductRepo : BaseRepo<ProductEntity>
{
    public ProductRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    private readonly DataContext _context;

    public override ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        try
        {
            var query = _context.Products
                .Include(i => i.Manufacture)
                .Include(i => i.Description)
                .Include(i => i.Review)
                .Include(i => i.PriceList)
                .Include(i => i.Category)
                .Where(predicate);

            return query.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            throw;
        }
    }

    public override IEnumerable<ProductEntity> GetAll()
    {
        try
        {
            return _context.Products
            .Include(i => i.Manufacture)
            .Include(i => i.Description)
            .Include(i => i.Review)
            .Include(i => i.PriceList)
            .Include(i => i.Category)
            .ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            throw;
        }

    }

}


using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Linq.Expressions;

namespace ShirtSkirt.Repositories;

internal class ProductRepository(DataContext context)
{
    private readonly DataContext _context = context;

    public ProductEntity Create(ProductEntity entity)
    {
        _context.Products.Add(entity);
        _context.SaveChanges();
        return entity;

    }

    public IEnumerable<ProductEntity> GetAll()
    {
        return _context.Products.ToList();
    }

    public ProductEntity GetOne(Expression<Func<ProductEntity, bool>> predicate)
    {
        var entity = _context.Products.FirstOrDefault(predicate);
        if (entity != null)
            return entity;
        else
            return null!;

    }


    public ProductEntity Update(ProductEntity entity)
    {
        var entityToUpdate = _context.Products.FirstOrDefault(x => x.ArticleNumber == entity.ArticleNumber);
        if (entityToUpdate != null)
        {
            entityToUpdate.CategoryName = entityToUpdate.CategoryName;
            _context.Products.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        return null!;

    }


    public bool Delete(int id)
    {
        var entity = _context.Products.FirstOrDefault(x => x.CategoryId == id);
        if (entity != null)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}

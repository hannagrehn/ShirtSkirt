
using ShirtSkirt.Contexts;
using ShirtSkirt.Entities;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace ShirtSkirt.Repositories;

public class CategoryRepository(DataContext context)
{
    private readonly DataContext _context = context;


    public CategoryEntity Create(CategoryEntity entity)
    {
        _context.Categories.Add(entity);
        _context.SaveChanges();
        return entity;

    }

    public IEnumerable<CategoryEntity> GetAll()
    {
        return _context.Categories.ToList();
    }

    public CategoryEntity GetOne(Expression<Func<CategoryEntity, bool>> predicate)
    {
        var entity = _context.Categories.FirstOrDefault(predicate);
        if (entity != null)
            return entity;
        else
            return null!;
        
    }


    public CategoryEntity Update(CategoryEntity entity)
    {
        var entityToUpdate = _context.Categories.FirstOrDefault(x => x.CategoryId == entity.CategoryId);
        if (entityToUpdate != null)
        {
            entityToUpdate.CategoryName = entityToUpdate.CategoryName;
            _context.Categories.Update(entity);
            _context.SaveChanges();
            return entity;
        }
        return null!;
        
    }


    public bool Delete(int id)
    {
        var entity = _context.Categories.FirstOrDefault(x => x.CategoryId == id);
        if (entity != null)
        {
            _context.Remove(entity);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
}

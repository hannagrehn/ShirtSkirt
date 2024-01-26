
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class CategoryService
{
    private readonly CategoryRepo _categoryRepo;

    public CategoryService(CategoryRepo categoryRepo)
    {
        _categoryRepo = categoryRepo;
    }

    public CategoryEntity CreateCategory(string categoryName)
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
        categoryEntity ??= _categoryRepo.Create(new CategoryEntity { CategoryName = categoryName });
        return categoryEntity; 
    }

    public CategoryEntity GetCategoryByName(string categoryName)
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == categoryName);
        return categoryEntity;
    }

    public CategoryEntity GetCategoryById(int id)
    {
        var categoryEntity = _categoryRepo.GetOne(x => x.CategoryId == id);
        return categoryEntity;
    }

    public IEnumerable<CategoryEntity> GetCategories()
    {
        var categories = _categoryRepo.GetAll();
        return categories;
    }

    public CategoryEntity UpdateCategory(CategoryEntity categoryEntity)
    {
        var updatedCategoryEntity = _categoryRepo.Update(x => x.CategoryId == categoryEntity.CategoryId, categoryEntity);
        return updatedCategoryEntity;
    }

    public bool DeleteCategory(int id)
    {
        try
        {
            return _categoryRepo.Delete(x => x.CategoryId == id);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
}

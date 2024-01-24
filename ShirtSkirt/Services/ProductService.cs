
using ShirtSkirt.Dtos;
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class ProductService(CategoryRepo categoryRepo, ProductRepo productRepo)
{
    private readonly CategoryRepo _categoryRepo = categoryRepo;
    private readonly ProductRepo _productRepo = productRepo;


    public bool CreateProduct(CreateProductDto product)
    {
        try
        {
            if (!_productRepo.Exists(x => x.ArticleNumber == product.ArticleNumber))
            {
                var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == product.CategoryName);
                categoryEntity ??= _categoryRepo.Create(new CategoryEntity { CategoryName = product.CategoryName });

                var productEntity = new ProductEntity
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    ManufactureEntity = new ManufactureEntity { ManufactureName = product.ManufactureName },
                    DescriptionEntity = new DescriptionEntity { Ingress = product.Ingress, LongDescription = product.LongDescription },
                    ReviewEntity = new ReviewEntity
                    {
                        ReviewerName = product.ReviewerName,
                        Rating = product.Rating,
                        ReviewText = product.ReviewText,
                        ReviewDate = product.ReviewDate
                    },
                    PricelistEntity = new PricelistEntity { Price = product.Price },
                    CategoryEntity = categoryEntity
                };

                var result = _productRepo.Create(productEntity);
                if (result != null)
                    return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }

        return false;
    }




    //public bool CreateProduct(CreateProductDto product)
    //{
    //    try
    //    {
    //        if (!_productRepo.Exists(x => x.ArticleNumber == product.ArticleNumber))
    //        {
    //            var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == product.CategoryName);
    //            categoryEntity ??= _categoryRepo.Create(new CategoryEntity { CategoryName = product.CategoryName });

    //            var productEntity = new ProductEntity
    //            {
    //                ArticleNumber = product.ArticleNumber,
    //                Title = product.Title,
    //                ManufactureId = product.ManufactureId,
    //                DescriptionId = product.DescriptionId,
    //                ReviewId = product.ReviewId,
    //                PriceId = product.PriceId,
    //                CategoryId = product.CategoryId,
    //            };

    //            var result = _productRepo.Create(productEntity);
    //            if (result != null)
    //                return true;
    //        }
    //    }
    //    catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }

    //    return false;
    //}

    public IEnumerable<ProductDto> GetAllProducts()
    {
        var products = new List<ProductDto>();

        try
        {
            var result = _productRepo.GetAll();


            foreach (var product in result)
                products.Add(new ProductDto
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    ManufactureId = product.ManufactureId,
                    DescriptionId = product.DescriptionId,
                    ReviewId = product.ReviewId,
                    PriceId = product.PriceId,
                    CategoryId = product.CategoryId,
                  
                });
        }
        catch(Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }


        return products;
    }
}

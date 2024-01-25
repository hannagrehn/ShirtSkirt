
using ShirtSkirt.Dtos;
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services;

public class ProductService(
    CategoryRepo categoryRepo,
    ProductRepo productRepo,
    DescriptionRepo descriptionRepo,
    ManufactureRepo manufactureRepo,
    PriceRepo priceRepo,
    ReviewRepo reviewRepo)
{
    private readonly CategoryRepo _categoryRepo = categoryRepo;
    private readonly ProductRepo _productRepo = productRepo;
    private readonly DescriptionRepo _descriptionRepo = descriptionRepo;
    private readonly ManufactureRepo _manufactureRepo = manufactureRepo;
    private readonly PriceRepo _priceRepo = priceRepo;
    private readonly ReviewRepo _reviewRepo = reviewRepo;

    public bool CreateProduct(CreateProductDto product)
    {
        try
        {
            if (!_productRepo.Exists(x => x.ArticleNumber == product.ArticleNumber))
            {
                
                var categoryEntity = _categoryRepo.GetOne(x => x.CategoryName == product.CategoryName)
                    ?? _categoryRepo.Create(new CategoryEntity { CategoryName = product.CategoryName });

                
                var manufactureEntity = _manufactureRepo.GetOne(x => x.ManufactureName == product.ManufactureName)
                    ?? _manufactureRepo.Create(new ManufactureEntity { ManufactureName = product.ManufactureName });

          
                var descriptionEntity = _descriptionRepo.Create(new DescriptionEntity { Ingress = product.Ingress, LongDescription = product.LongDescription });

              
                var reviewEntity = _reviewRepo.Create(new ReviewEntity
                {
                    ReviewerName = product.ReviewerName,
                    Rating = product.Rating,
                    ReviewText = product.ReviewText,
                    ReviewDate = product.ReviewDate
                });

    
                var pricelistEntity = _priceRepo.Create(new PricelistEntity { Price = product.Price });

                var productEntity = new ProductEntity
                {
                    ArticleNumber = product.ArticleNumber,
                    Title = product.Title,
                    ManufactureEntity = manufactureEntity,
                    DescriptionEntity = descriptionEntity,
                    ReviewEntity = reviewEntity,
                    PricelistEntity = pricelistEntity,
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

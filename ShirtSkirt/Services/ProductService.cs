
using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;


namespace ShirtSkirt.Services;

public class ProductService
{
    private readonly ProductRepo _productRepo;
    private readonly CategoryService _categoryService;
    private readonly DescriptionService _descriptionService;
    private readonly ManufactureService _manufacturerService;
    private readonly PriceService _priceService;
    private readonly ReviewService _reviewService;

    public ProductService(ProductRepo productRepo, CategoryService categoryService, DescriptionService descriptionService, ManufactureService manufacturerService, PriceService priceService, ReviewService reviewService)
    {
        _productRepo = productRepo;
        _categoryService = categoryService;
        _descriptionService = descriptionService;
        _manufacturerService = manufacturerService;
        _priceService = priceService;
        _reviewService = reviewService;
    }



    public ProductEntity CreateProduct(
        string articleNumber, 
        string title, 
        string manufactureName, 
        string ingress, 
        string longDescription, 
        string reviewText, 
        int rating,
        string reviewerName,
        DateTime reviewDate,
        decimal price, 
        string categoryName)

    {

        var categoryEntity = _categoryService.CreateCategory(categoryName);
        var descriptionEntity = _descriptionService.CreateDescription(ingress, longDescription);
        var manufactureEntity = _manufacturerService.CreateManufacture(manufactureName);
        var pricelistEntity = _priceService.CreatePrice(price);
        var reviewEntity = _reviewService.CreateReview(reviewText, rating, reviewerName, reviewDate);


        try
        {
            var productEntity = new ProductEntity
            {
                ArticleNumber = articleNumber,
                Title = title,
                CategoryId = categoryEntity.CategoryId,
                DescriptionId = descriptionEntity.DescriptionId,
                ManufactureId = manufactureEntity.ManufactureId,
                PriceId = pricelistEntity.PriceId,
                ReviewId = reviewEntity.ReviewId
            };

            productEntity = _productRepo.Create(productEntity);
            return productEntity;

        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }


    public ProductEntity GetProductByTitle(string title)
    {
        var productEntity = _productRepo.GetOne(x => x.Title == title);
        return productEntity;
    }


    public ProductEntity GetProductByArticleNumber(string articleNumber)
    {
        var productEntity = _productRepo.GetOne(x => x.ArticleNumber == articleNumber);
        return productEntity;
    }


    public IEnumerable<ProductEntity> GetProducts()
    {
        var products = _productRepo.GetAll();
        return products;
    }


    public ProductEntity UpdateProduct(ProductEntity productEntity)
    {
        var updatedProductEntity = _productRepo.Update(x => x.ArticleNumber == productEntity.ArticleNumber, productEntity);
        return updatedProductEntity;
    }


    public bool DeleteProduct(string articleNumber)
    {
        try
        {
            return _productRepo.Delete(x => x.ArticleNumber == articleNumber);
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
            return false;
        }
    }
}


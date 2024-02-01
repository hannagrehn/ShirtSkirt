using ShirtSkirt.Entities;
using ShirtSkirt.Repositories;
using System.Diagnostics;

namespace ShirtSkirt.Services
{
    public class ProductService(ProductRepo productRepo, CategoryService categoryService, DescriptionService descriptionService, ManufactureService manufacturerService, PriceService priceService, ReviewService reviewService)
    {
        private readonly ProductRepo _productRepo = productRepo;
        private readonly CategoryService _categoryService = categoryService;
        private readonly DescriptionService _descriptionService = descriptionService;
        private readonly ManufactureService _manufacturerService = manufacturerService;
        private readonly PriceService _priceService = priceService;
        private readonly ReviewService _reviewService = reviewService;

        public ProductEntity CreateProduct(
            string articleNumber,
            string title,
            string manufactureName,
            string ingress,
            string longDescription,
            decimal price,
            string categoryName,
            string reviewText,
            int rating,
            string reviewerName,
            DateOnly reviewDate)
        {
            try
            {
                var categoryEntity = _categoryService.CreateCategory(categoryName);
                var descriptionEntity = _descriptionService.CreateDescription(ingress, longDescription);
                var manufactureEntity = _manufacturerService.CreateManufacture(manufactureName);
                var pricelistEntity = _priceService.CreatePrice(price);
                var reviewEntity = _reviewService.CreateReview(reviewText, rating, reviewerName, reviewDate);

                if (categoryEntity != null && descriptionEntity != null && manufactureEntity != null &&
                    pricelistEntity != null && reviewEntity != null)
                {
                    var productEntity = new ProductEntity
                    {
                        ArticleNumber = articleNumber,
                        Title = title,
                        CategoryId = categoryEntity.CategoryId,
                        DescriptionId = descriptionEntity.DescriptionId,
                        ManufactureId = manufactureEntity.ManufactureId,
                        PriceListId = pricelistEntity.PriceId,
                        ReviewId = reviewEntity.ReviewId
                    };

                    if (_productRepo != null)
                    {
                        productEntity = _productRepo.Create(productEntity);
                        return productEntity;
                    }
                    else
                    {
                        Debug.WriteLine("Error :: _productRepo is null.");
                    }
                }
                else
                {
                    Debug.WriteLine("Error :: One or more entities are null.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error :: " + ex.Message);
            }

            return null!;
        }

        public ProductEntity GetProductByTitle(string title)
        {
            Console.WriteLine($"Searching for product with Title: {title}");

            var productEntity = _productRepo.GetOne(x => x.Title == title);

            if (productEntity != null)
            {
                Console.WriteLine($"Product found - Article Number: {productEntity.ArticleNumber}, Title: {productEntity.Title}");
            }
            else
            {
                Console.WriteLine("Debug: No product found.");
            }

            return productEntity!;
        }


        public ProductEntity GetProductByArticleNumber(string articleNumber)
        {
            Console.WriteLine($"Searching for product with Article Number: {articleNumber}");
            

            var lowerArticleNumber = articleNumber.ToLower();
            var productEntity = _productRepo.GetOne(x => x.ArticleNumber.ToLower() == lowerArticleNumber);

            if (productEntity != null)
            {
                Console.Clear();
                Console.WriteLine($"Product found - Title: {productEntity.Title}, Category: {productEntity.Category.CategoryName}, Price: {productEntity.PriceList.Price} SEK");
            }
            else
            {
                Console.WriteLine("No product found.");
            }

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
}

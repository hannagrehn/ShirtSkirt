
using ShirtSkirt.Services;
using System.Diagnostics;

namespace ShirtSkirt;

public class UserScreen
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public UserScreen(ProductService productService, CategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public void DisplayMenu(UserScreen userScreen)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Create Product");
            Console.WriteLine("2. Get Products");
            Console.WriteLine("3. Add Category");
            Console.WriteLine("4. Update Product");
            Console.WriteLine("5. Delete Product");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    userScreen.CreateProduct_UI();
                    break;
                case "2":
                    userScreen.GetProducts_UI();
                    break;
                case "3":
                    userScreen.AddCategory_UI();
                    break;
                case "4":
                    userScreen.UpdateProduct_UI();
                    break;
                case "5":
                    userScreen.DeleteProduct_UI();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
           
            Console.ReadKey();
        }
    }

    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Create Product ***");

        Console.WriteLine("\nProduct articlenumber: ");
        var articleNumber = Console.ReadLine()!;

        Console.WriteLine("Product title: ");
        var title = Console.ReadLine()!;

        Console.WriteLine("Product manufacture: ");
        var manufactureName = Console.ReadLine()!;

        Console.WriteLine("Product category: ");
        var categoryName = Console.ReadLine()!;

        Console.WriteLine("Enter the price: ");
        string priceInput = Console.ReadLine()!;

        if (decimal.TryParse(priceInput, out decimal price) && price >= 0)
        {
            Console.WriteLine($"You entered a valid price: {price:C}");
        }

        Console.WriteLine("Product ingress: ");
        var ingress = Console.ReadLine()!;

        Console.WriteLine("Product long description: ");
        var longDescription = Console.ReadLine()!;

        Console.WriteLine("Product review: ");
        var reviewText = Console.ReadLine()!;

        Console.WriteLine("Product reviewers name: ");
        var reviewerName = Console.ReadLine()!;

        Console.WriteLine("Product date of review (yyyy-mm-dd): ");
        string reviewDateInput = Console.ReadLine()!;

        if (DateOnly.TryParse(reviewDateInput, out DateOnly reviewDate))
        {
            Console.WriteLine($"You entered: {reviewDate}");
        }
      
        Console.WriteLine("Product rating: ");

        if (int.TryParse(Console.ReadLine(), out int rating))
        {

            Console.WriteLine($"You entered: {rating}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer for the rating.");
        }

        var result = _productService.CreateProduct
            (articleNumber,
            title,
            manufactureName,
            ingress,
            longDescription, 
            price,
            categoryName,
            reviewText,
            rating,
            reviewerName,
            reviewDate
            );
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Your product has been created!");
            Console.ReadKey();
        }
        else Console.WriteLine("No product for you.");
    }

    public void GetProducts_UI()
    {   
        var products = _productService.GetProducts();
        Console.Clear();
        Console.WriteLine("*** All products ***\n");
       
        foreach ( var product in products )
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.PriceList.Price} SEK");
        }
        
    }

    public void AddCategory_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Add category ***\n ");
        Console.WriteLine("Category name: ");
        var categoryName = Console.ReadLine()!;
        
        var result = _categoryService.CreateCategory(categoryName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine($"Your category {categoryName} has been created!");
            Console.ReadKey();
        }
        else Console.WriteLine("No catagory has been created.");
        Console.ReadKey();
    }

    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Update product ***");
        Console.WriteLine("\nEnter product article number: ");
        var articleNumber = Console.ReadLine()!;

        var product = _productService.GetProductByArticleNumber(articleNumber);

        try
        {
            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"Article number entered: {articleNumber}");
                Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.PriceList.Price} SEK");
                Console.WriteLine();

                Console.Write("New product title: ");
                product.Title = Console.ReadLine()!;

                var newProduct = _productService.UpdateProduct(product);
                Console.Clear();
                Console.WriteLine("*** Behold your new product! ***\n");
                Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.PriceList.Price} SEK");
            }
            else
            {
                Console.WriteLine("No product found.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
    }

    public void DeleteProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Delete product ***\n");
        Console.WriteLine("Enter product article number: ");
        var articleNumber = Console.ReadLine()!;

        var product = _productService.GetProductByArticleNumber(articleNumber);
        try
        {
            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"Do you want to delete {product.Title}?");
                var userInput = Console.ReadLine()!;

                if (userInput == "y")
                {
                    _productService.DeleteProduct(product.ArticleNumber);
                    Console.Clear();
                    Console.WriteLine($"{product.ArticleNumber} - {product.Title} was deleted.");
                }
                else if (userInput == "n") 
                {
                    Console.WriteLine("No product deleted.");                  
                }
                else
                {
                    Console.WriteLine("Invalid input.");                 
                }
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"No product found with atricle number {articleNumber}.");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
    }


    //bunch of shirt going on down here
    public void TestGetProductByArticleNumber()
    {
        Console.WriteLine("Testing GetProductByArticleNumber");
        var testArticleNumber = "A3";
        var product = _productService.GetProductByArticleNumber(testArticleNumber);

        if (product != null)
        {
            Console.WriteLine($"Product Found: {product.ArticleNumber} - {product.Title}");
        }
        else
        {
            Console.WriteLine("No product found.");
        }
    }

    public void TestGetProductByTitle()
    {
        Console.WriteLine("Testing GetProductByTitle");
        Console.WriteLine("Enter test product title: ");
        var testTitle = Console.ReadLine()?.Trim()!;
        var product = _productService.GetProductByTitle(testTitle);

        if (product != null)
        {
            Console.Clear();
            Console.WriteLine($"Product Found: {product.ArticleNumber} - {product.Title}");
        }
        else
        {
            Console.WriteLine("No product found.");
        }
    }




}


using ShirtSkirt.Services;
using System.Diagnostics;

namespace ShirtSkirt;

public class UserScreen
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;

    public UserScreen(ProductService productService)
    {
        _productService = productService;
    }

    public void CreateProduct_UI()
    {
        Console.WriteLine("*** Create Product ***");

        Console.WriteLine("Product articlenumber: ");
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
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid positive decimal");
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
        else
        {
            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-mm-dd).");
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
        else Console.WriteLine("Nope");
    }

    public void GetProducts_UI()
    {
        var products = _productService.GetProducts();
        foreach ( var product in products )
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName} - {product.PriceList.Price} SEK");
        }

        Console.ReadKey();
    }

    public void AddCategory_UI()
    {
        Console.WriteLine("Product Category: ");
        var categoryName = Console.ReadLine()!;

        var result = _categoryService.CreateCategory(categoryName);

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Your category has been created!");
            Console.ReadKey();
        }
        else Console.WriteLine("Nope");
        Console.ReadKey();
    }

    public void UpdateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("Enter product title: ");
        var id = Console.ReadLine()!;
        var product = _productService.GetProductByTitle(id);
    }


}


using ShirtSkirt.Services;

namespace ShirtSkirt;

public class UserScreen
{
    private readonly ProductService _productService;

    public UserScreen(ProductService productService)
    {
        _productService = productService;
    }

    public void CreateProduct_UI()
    {
        Console.WriteLine("*** Create Product ***");

        Console.WriteLine("Product Article Number: ");
        var articleNumber = Console.ReadLine()!;

        Console.WriteLine("Product Title: ");
        var title = Console.ReadLine()!;

        Console.WriteLine("Product Manufacture: ");
        var manufactureName = Console.ReadLine()!;

        Console.WriteLine("Product Category: ");
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


        Console.WriteLine("Product Ingress: ");
        var ingress = Console.ReadLine()!;

        Console.WriteLine("Product Long Description: ");
        var longDescription = Console.ReadLine()!;

        Console.WriteLine("Product Review: ");
        var reviewText = Console.ReadLine()!;

        Console.WriteLine("Product Reviewers name: ");
        var reviewerName = Console.ReadLine()!;


        Console.WriteLine("Product date of review (yyyy-MM-dd): ");
        string reviewDateInput = Console.ReadLine()!;

        if (DateOnly.TryParse(reviewDateInput, out DateOnly reviewDate))
        {
            Console.WriteLine($"You entered: {reviewDate}");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please enter a valid date (yyyy-MM-dd).");
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
        else Console.WriteLine("nope");
    }
}

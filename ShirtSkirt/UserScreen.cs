
using ShirtSkirt.Services;
using System.Diagnostics;
using System.Drawing;


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
        int selectedIndex = 0;
        List<Action> menuActions = new List<Action>
        {
        userScreen.CreateProduct_UI,
        userScreen.GetProducts_UI,
        userScreen.AddCategory_UI,
        userScreen.UpdateProduct_UI,
        userScreen.DeleteProduct_UI,
        userScreen.Hangman,
        () => Environment.Exit(0)
        };

        while (true)
        {
            Console.Clear();

            WriteLogo();

            Console.WriteLine("=== Menu ===");

            for (int i = 0; i < menuActions.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        
                }

                Console.WriteLine($"{i + 1}. {GetMenuItemName(i)}");

                Console.ResetColor();
            }

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + menuActions.Count) % menuActions.Count;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % menuActions.Count;
                    break;
                case ConsoleKey.Enter:
                    menuActions[selectedIndex].Invoke();
                    break;
            }         
        }
    }

    private string GetMenuItemName(int index)
    {
        switch (index)
        {
            case 0: return "Create product";
            case 1: return "Show all";
            case 2: return "Add category";
            case 3: return "Update product";
            case 4: return "Delete product";
            case 5: return "Play hangman";
            case 6: return "Exit";
            default: return "Unknown";
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
        Console.ReadKey();
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
        Console.ReadKey();

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
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No product found.");
                Console.ReadKey();
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
                Console.WriteLine($"Do you want to delete {product.Title}?");
                var userInput = Console.ReadLine()!;

                if (userInput == "y")
                {
                    _productService.DeleteProduct(product.ArticleNumber);
                    Console.Clear();
                    Console.WriteLine($"{product.ArticleNumber} - {product.Title} was deleted.");
                    Console.ReadKey();
                }
                else if (userInput == "n") 
                {
                    Console.WriteLine("No product deleted.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    Console.ReadKey();
                }            
            }
            else
            {              
                Console.WriteLine($"No product found with atricle number {articleNumber}.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
    }


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


    public void Hangman()
    {    
        string[] words = { "ginger", "headphones", "python", "csharp", "mouse", "bread" };
        Random random = new Random();
        string selectedWord = words[random.Next(words.Length)];
        char[] wordToGuess = selectedWord.ToCharArray();
        char[] guessedLetters = new char[wordToGuess.Length];
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = '_';
        }
        Console.Clear();
        Console.WriteLine("*** Let's play hangman! One key at the time. ***");
        int attemptsLeft = 10;
        while (attemptsLeft > 0)
        {
            
            Console.WriteLine("Current word: " + new string(guessedLetters));
            Console.WriteLine("Guess a letter: ");
            char guess = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            Console.Clear();
            bool correctGuess = false;
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                
                if (wordToGuess[i] == guess)
                {
                    Console.WriteLine("Correct!");
                    guessedLetters[i] = guess;
                    correctGuess = true;
                }
            }
            if (!correctGuess)
            {
                attemptsLeft--;
                Console.WriteLine("Nope! Attempts left: " + attemptsLeft);
            }

            if (new string(guessedLetters) == selectedWord)
            {
                Console.Clear();
                Console.WriteLine($"Congrats! You guessed the word: {selectedWord}." );
                break;
            }
        }
        if (attemptsLeft == 0)
        {
            Console.WriteLine($"Sorry, no attempts left. The correct word was: {selectedWord}.");
        }
        Console.WriteLine("\nThanks for playing!");
        Console.ReadKey();
    }

    public void WriteLogo()
    {
        string logo = @"
 .-. .             .     .-. .             .  
(   )|      o     _|_   (   )|      o     _|_ 
 `-. |--.   .  .--.|     `-. |.-.   .  .--.|  
(   )|  |   |  |   |    (   )|-.'   |  |   |  
 `-' '  `--' `-'   `-'   `-' '  `--' `-'   `-'
                      ";
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine(logo);
        Console.ResetColor();
    }
}

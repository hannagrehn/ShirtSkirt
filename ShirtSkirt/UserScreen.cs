using ShirtSkirt.Services;
using System.Diagnostics;

namespace ShirtSkirt;

public class UserScreen
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly ProfileService _profileService;

    public UserScreen(ProductService productService, CategoryService categoryService, ProfileService profileService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _profileService = profileService;
    }

    public void DisplayMenu(UserScreen userScreen)
    {
        int selectedIndex = 0;
        List<Action> menuActions = new List<Action>
        {
        userScreen.CreateProduct_UI,
        userScreen.GetProducts_UI,
        userScreen.UpdateProduct_UI,
        userScreen.DeleteProduct_UI,

        userScreen.CreateProfile_UI,
        userScreen.GetProfiles_UI,
        userScreen.UpdateProfile_UI,
        userScreen.DeleteProfile_UI,

        userScreen.Hangman,
        () => Environment.Exit(0)
        };

        while (true)
        {
            Console.Clear();
            WriteLogo();
            Console.WriteLine("                 === Menu ===");

            for (int i = 0; i < menuActions.Count; i++)
            {
                if (i == selectedIndex)
                {              
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;                       
                }
                Console.WriteLine($"               {i + 1}. {GetMenuItemName(i)}");
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
            case 2: return "Update product";
            case 3: return "Delete product";

            case 4: return "Create profile";
            case 5: return "Show all profiles";
            case 6: return "Update alliance";
            case 7: return "Delete profile";


            case 8: return "Play hangman";
            case 9: return "Exit";
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
                Console.WriteLine($"\nDo you want to delete {product.Title}? (y/n)");
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
                Console.Clear();
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
        string[] words = { "ERROR", "HEADPHONES", "PYTHON", "CSHARP", "HANS", "MOUSE", "DELETE", "DOTNET" };
        Random random = new Random();
        string selectedWord = words[random.Next(words.Length)];
        char[] wordToGuess = selectedWord.ToCharArray();
        char[] guessedLetters = new char[wordToGuess.Length];
        for (int i = 0; i < guessedLetters.Length; i++)
        {
            guessedLetters[i] = '_';
        }

        List<char> wrongGuesses = new List<char>();
        Console.Clear();
        Console.WriteLine("*** Let's play hangman! One key at the time. ***");
        int attemptsLeft = 10;

        while (attemptsLeft > 0)
        {
            Console.WriteLine("Current word: " + new string(guessedLetters));
            Console.Write("Wrong guesses: ");
            foreach (char wrongGuess in wrongGuesses)
            {
                if (wrongGuesses.Count(g => g == wrongGuess) > 1)
                {
                    Console.Write(wrongGuess + ", ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(wrongGuess + " ");
                }
            }

            Console.Write("\n\nGuess a letter: ");
            char guess = char.ToUpper(Console.ReadKey().KeyChar);

            Console.Clear();
            bool correctGuess = false;
            bool alreadyGuessed = guessedLetters.Contains(guess) || wrongGuesses.Contains(guess);

            if (!alreadyGuessed)
            {
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
                    wrongGuesses.Add(guess);
                }
            }
            else
            {
                Console.WriteLine($"You already guessed {guess}! Try a different letter.");
            }

            if (new string(guessedLetters) == selectedWord)
            {
                Console.Clear();
                Console.WriteLine($"Congrats! You guessed the word: {selectedWord}");
                break; 
            }
        }

        if (new string(guessedLetters) != selectedWord)
        {
            Console.WriteLine($"Sorry, no attempts left. The correct word was: {selectedWord}");
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

    //Profiles begin here

    //userscreen.CreateProfile_UI,
    //userscreen.GetProfile_UI,
    //userscreen.UpdateAlliance_UI,
    //userscreen.DeleteProfile_UI,

    public void CreateProfile_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Create Profile ***");
        Console.WriteLine("\nProfile ID: ");
        int profileId;
        if (!int.TryParse(Console.ReadLine(), out profileId))
        {
            Console.WriteLine("Invalid input for Profile ID. Please enter a valid integer value.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("First name: ");
        var firstName = Console.ReadLine()!;

        Console.WriteLine("Last name: ");
        var lastName = Console.ReadLine()!;

        Console.WriteLine("Enter alliance: ");
        var alliance = Console.ReadLine()!;

        Console.WriteLine("Enter language: ");
        var language = Console.ReadLine()!;
  
        Console.WriteLine("Enter role: ");
        var role = Console.ReadLine()!;


        var result = _profileService.CreateProfile
            (profileId,
            firstName,
            lastName,
            alliance,
            language,
            role              
            );

        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Your profile has been created!");
            Console.ReadKey();
        }
        else Console.WriteLine("No profile today.");
        Console.ReadKey();
    }




    public void GetProfiles_UI()
    {
        var profiles = _profileService.GetProfiles();
        Console.WriteLine("*** All profiles ***\n");

        foreach (var profile in profiles)
        {    
            string allianceName = profile.Alliance != null ? profile.Alliance.AllianceName : "No Alliance";
            Console.WriteLine($"{profile.FirstName} {profile.LastName}, Alliance: {allianceName}");
        }
        Console.ReadKey();
    }





    public void UpdateProfile_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Update last name ***");
        Console.WriteLine("\nEnter last name: ");
        var lastName = Console.ReadLine()!;
        var profile = _profileService.GetProfileByLastName(lastName);

        try
        {
            if (profile != null)
            {
                Console.Clear();
                Console.WriteLine($"Profile containing: {lastName}: ");
                Console.WriteLine($"{profile.FirstName} {profile.LastName} - {profile.Alliance}");
                Console.WriteLine();

                Console.Write("New last name: ");
                profile.LastName = Console.ReadLine()!;

                var newProfile = _profileService.UpdateProfile(profile);
                Console.Clear();
                Console.WriteLine("*** Behold your new last name! ***\n");
                Console.WriteLine($"{profile.FirstName} - {profile.LastName} - {profile.Alliance} ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No profile found.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
    }





    public void DeleteProfile_UI()
    {
        Console.Clear();
        Console.WriteLine("*** Delete profile ***\n");
        Console.WriteLine("Enter profile last name: ");
        var lastName = Console.ReadLine()!;

        var profile = _profileService.GetProfileByLastName(lastName);
        try
        {
            if (profile != null)
            {
                Console.WriteLine($"\nDo you want to delete {profile.FirstName} {profile.LastName}? (y/n)");
                var userInput = Console.ReadLine()!;

                if (userInput == "y")
                {
                    _profileService.DeleteProfile(profile.LastName);
                    Console.Clear();
                    Console.WriteLine($"{profile.LastName} - {profile.LastName} was deleted.");
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
                Console.Clear();
                Console.WriteLine($"No profile found with last name {lastName}.");
                Console.ReadKey();
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("Error :: " + ex.Message);
        }
    }
}

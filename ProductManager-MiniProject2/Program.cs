

// Class representing the program
class Program
{
    // Main method, entry point of the program
    static void Main(string[] args)
    {
        // Set console text color to dark yellow
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        // Display welcome message
        Console.WriteLine("Welcome to the Product Catalog!" +
            "\nTo use the app follow the steps:");
        // Reset console text color
        Console.ResetColor();

        // List to store products
        List<Product> productList = new List<Product>();

        // Loop to display menu and handle user input
        while (true)
        {
            // Display menu options
            Console.WriteLine(" ");
            Console.WriteLine("Enter a number:");
            Console.WriteLine("1-Add a Product");
            Console.WriteLine("2-Search a Product");
            Console.WriteLine("3-List Products");
            Console.WriteLine("0-Quit");

            // Get user choice
            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            // Validate user input
            if (!isValidChoice)
            {
                // Display error message for invalid input
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.ResetColor();
                continue;
            }

            // Handle user choice using a switch statement
            switch (choice)
            {
                // Exit the program
                case 0:
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Thank you for using the Product Catalog!");
                    return;
                case 1:
                    // Add a new product
                    AddProduct(productList);
                    break;
                case 2:
                    // Search for a product
                    SearchProduct(productList);
                    break;
                case 3:
                    // Display the list of products
                    DisplayProductList(productList);
                    break;
                default:
                    // Display error message for invalid menu choice
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please choose a number from the menu.");
                    Console.ResetColor();
                    break;
            }
        }
    }

    // Method to add a product to the list
    static void AddProduct(List<Product> productList)
    {
        // Set console text color to dark yellow
        Console.ForegroundColor= ConsoleColor.DarkYellow;
        Console.WriteLine("\nEnter product details:");
        Console.WriteLine("-------------------------");
        Console.ResetColor();
        Console.Write("Category: ");
        string category = Console.ReadLine().ToLower();

        Console.Write("Product Name: ");
        string name = Console.ReadLine();

        double price;
        Console.Write("Price: ");
        bool isValidPrice = double.TryParse(Console.ReadLine(), out price);

        // Validate the price input
        if (!isValidPrice)
        {
            // Display error message for invalid price
            Console.WriteLine("Invalid input. Please enter a valid price.");
            return;
        }
        Console.ForegroundColor = ConsoleColor.Green;
        // Add the new product to the list
        productList.Add(new Product(category, name, price));
        Console.WriteLine("Product added successfully!");
        Console.ResetColor();
        Console.WriteLine("----------------------------");
    }

    // Method to search for a product by name
    static void SearchProduct(List<Product> productList)
    {
        // Set console text color to dark yellow
        Console.ForegroundColor= ConsoleColor.DarkYellow ;
        Console.Write("\nEnter product name to search: ");
        Console.ResetColor();
        string searchName = Console.ReadLine().ToLower();

        // Search for products matching the given name
        var foundProducts = productList.Where(p => p.Name.ToLower().Contains(searchName));

        if (foundProducts.Any())
        {
            // Display found products
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nFound Products:");
            Console.WriteLine("------------------");
            foreach (var product in foundProducts)
            {   Console.ForegroundColor = ConsoleColor.Blue;
                // Display header for product details
                Console.WriteLine("Category".PadRight(15) + "Name".PadRight(10) + "Price".PadRight(10));
                Console.ForegroundColor = ConsoleColor.Green;
                // Display product details
                Console.WriteLine($"{product.Category.PadRight(15)}{product.Name.PadRight(10)}{product.Price}" + "$");
                Console.ResetColor();

            }

        }
        else
        {
            // Display message for no products found
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No products found with the given name.");
            Console.ResetColor();
        }
        Console.WriteLine("----------------------------");
    }

    // Method to display the list of products
    static void DisplayProductList(List<Product> productList)
    {
        // Set console text color to blue
        Console.ForegroundColor= ConsoleColor.Blue ;
        Console.WriteLine("\nProduct List:");
        Console.WriteLine("------------------");
        Console.ResetColor();

        if (productList.Count > 0)
        {
            // Order the products by price
            productList = productList.OrderBy(p => p.Price).ToList();
            double totalPrice = 0;
            Console.ForegroundColor = ConsoleColor.Blue;
            // Display header for product details
            Console.WriteLine("Category".PadRight(15) + "Name".PadRight(10) + "Price".PadRight(10));

            foreach (var product in productList)
            {
                // Display product details
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{product.Category.PadRight(15)}{product.Name.PadRight(10)}{product.Price}" + "$");
                Console.ResetColor();
                totalPrice += product.Price;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            // Display total price of all products
            Console.WriteLine("\n".PadRight(10) + "Total Price:".PadRight(16) + $"{totalPrice}" + "$");
            Console.ResetColor();
        }
        else
        {
            // Display message for no products added
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No products added.");
            Console.ResetColor();
        }
        Console.WriteLine("----------------------------");
    }
}

// Class representing a product
class Product
{
    // Properties for category, name, and price of the product
    public string Category { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    // Constructor to initialize the product with category, name, and price
    public Product(string category, string name, double price)
    {
        Category = category;
        Name = name;
        Price = price;
    }
}
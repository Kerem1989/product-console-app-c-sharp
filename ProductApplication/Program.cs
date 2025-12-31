// See https://aka.ms/new-console-template for more information

using ProductApplication.Domain;
using ProductApplication.Service;

public class Program
{
    public static void Main(string[] args)
    {
        List<Product> products = new List<Product>();
        ProductService productService = new ProductService();
        bool runProgram = true;
        bool isEmpty = false;

        while (runProgram)
        {
            Console.WriteLine("Product Management");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update stock");
            Console.WriteLine("3. Delete product");
            Console.WriteLine("4. View all products");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? (choose 1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    bool duplicate = productService.CheckDuplicate(name, products);
                    if (duplicate)
                    {
                        Console.WriteLine("Duplicate Product Name: " + name);
                        Console.WriteLine("Product not added.");
                    }
                    else
                    {
                        Console.Write("Enter Product Price: ");
                        bool price = decimal.TryParse(Console.ReadLine(), out decimal parsedPrice);
                        if (!price)
                        {
                            Console.WriteLine("Invalid price format. Product not added.");
                            break;
                        }
                        else
                        {
                            Console.Write("Enter Product Quantity: ");
                            bool quantity = int.TryParse(Console.ReadLine(), out int parsedQuantity);
                            if (!quantity)
                            {
                                Console.WriteLine("Invalid quantity format. Product not added.");
                                break;
                            }
                            else
                            {
                                productService.AddProduct(name, parsedPrice, parsedQuantity, products);
                                Console.WriteLine("Product added successfully!");
                            }
                        }
                    }
                    break;
                case "2":
                    isEmpty = productService.ProductListEmpty(products);
                    if (isEmpty)
                    {
                        Console.WriteLine("No products available to update.");
                    }
                    else
                    {
                        Console.Write("From the list of products, enter the name of the product to update stock: ");
                        productService.DisplayProducts(products);
                        string updateName = Console.ReadLine();
                        bool correctName = productService.CorrectName(updateName, products);
                        if (!correctName)
                        {
                            Console.WriteLine("Incorrect product name.");
                        }
                        else
                        {
                            Console.Write("Enter new quantity: ");
                            bool validInput = int.TryParse(Console.ReadLine(), out int parsedQuantity);
                            if (!validInput)
                            {
                                Console.WriteLine("Invalid quantity format. Stock not updated.");
                                break;
                            }
                            else
                            {
                                productService.UpdateStock(updateName, parsedQuantity, products);
                                Console.WriteLine("Stock updated successfully!");
                            }
                        }
                    }
                    break;
                case "3":
                    isEmpty = productService.ProductListEmpty(products);
                    if (isEmpty)
                    {
                        Console.WriteLine("No products available to remove.");
                    }
                    else
                    {
                        Console.Write("From the list of products, enter the name of the product to delete: ");
                        productService.DisplayProducts(products);
                        string deleteName = Console.ReadLine();
                        bool correctName = productService.CorrectName(deleteName, products);
                        if (!correctName)
                        {
                            Console.WriteLine("Incorrect product name.");
                        }
                        else
                        {
                            productService.DeleteProduct(deleteName, products);
                            Console.WriteLine("Product deleted successfully!");
                        }
                    }
                    break;
                case "4":
                    isEmpty = productService.ProductListEmpty(products);
                    if (isEmpty)
                    {
                        Console.WriteLine("No products available.");
                    }
                    else
                    {
                        productService.DisplayProducts(products);
                    }
                    break;
                case "5":
                    runProgram = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
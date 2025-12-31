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
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.Write("Enter Product Quantity: ");
                        int quantity = int.Parse(Console.ReadLine());
                        productService.AddProduct(name, price, quantity, products);
                        Console.WriteLine("Product added successfully!");
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
                            int newQuantity = int.Parse(Console.ReadLine());
                            productService.UpdateStock(updateName, newQuantity, products);
                            Console.WriteLine("Stock updated successfully!");
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
            }
        }
    }
}
using ProductApplication.Domain;

namespace ProductApplication.Service ;

    public class ProductService
    {
        public void AddProduct(string name, decimal price, int quantity, List <Product> products)
        {
            Product product = new Product();
            product.Name = name;
            product.Price = price;
            product.Quantity = quantity;
            products.Add(product);
        }
        
        public bool CorrectName(string name, List <Product> products)
        {
            foreach (var product in products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool CheckDuplicate(string name, List <Product> products)
        {
            foreach (var product in products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void UpdateStock(string name, int quantity, List<Product> products)
        {
            foreach (var product in products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    product.Quantity = quantity;
                    break;
                }
            }
        }
        
        public bool ProductListEmpty(List<Product> products)
        {
            if (products.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void DisplayProducts(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                Console.WriteLine("Product List:");
                foreach (var product in products)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }

        public void DeleteProduct(string name, List<Product> products)
        {
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    products.RemoveAt(i);
                    break;
                }
            }
        }
    }
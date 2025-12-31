namespace ProductApplication.Domain ;

    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        
        public override string ToString()
        {
            return $"Product Name: {Name}, Price: {Price:C}, Quantity: {Quantity}";
        }
    }
namespace OrderFlow.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ProductCategory { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
         public decimal Price { get; set; }
        public int Stock {  get; set; }


    }
}

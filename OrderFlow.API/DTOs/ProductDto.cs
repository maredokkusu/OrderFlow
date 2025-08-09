namespace OrderFlow.API.DTOs
{
    //Reduces the info of a normal Product
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        = string.Empty;
        
        public string ProductCategory { get; set; } = string.Empty;
        public string ProductType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; } = string.Empty;

}

}

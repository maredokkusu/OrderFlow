namespace OrderFlow.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        
        public string ProductName { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
}
        public class CreateOrderDto { 
            public string ProductName { get; set; }
            public int Quantity { get; set; }
    }
}

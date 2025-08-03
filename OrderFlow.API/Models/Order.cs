namespace OrderFlow.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int Quantity { get; set; }
        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }
        
        public decimal TotalAmount { get; set; }

    }
}

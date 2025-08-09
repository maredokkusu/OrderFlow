namespace OrderFlow.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }

        public int Quantity { get; set; }
         
        public Customer Customer  { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalAmount { get; set; }

    };
}

using OrderFlow.API.Models;

namespace OrderFlow.API.DTOs
{
    //Respresent the atributtes that a client can give to the order
    public class CreateOrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public Customer Customer { get; set; }

        public List<OrderItem> Items { get; set; }
        public int CustomerId {get;set;}
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}

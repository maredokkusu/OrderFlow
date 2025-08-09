namespace OrderFlow.API.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public List<OrderItemSummaryDto> Items { get; set; } = new();

        public decimal TotalAmount { get; set; }
    }

}

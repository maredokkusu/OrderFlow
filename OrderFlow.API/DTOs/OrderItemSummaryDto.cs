namespace OrderFlow.API.DTOs
{
    public class OrderItemSummaryDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        
        public string ProductName { get; set; } = string.Empty;
    }
}

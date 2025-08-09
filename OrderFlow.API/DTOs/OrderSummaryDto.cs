using Microsoft.AspNetCore.Http.Features;
using OrderFlow.API.Models;

namespace OrderFlow.API.DTOs
{
    //Represent a Summary of a order created by the client
    public class OrderSummaryDto
    {
        public int Id { get; set; }

        public string CustomerName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public List<OrderItemSummaryDto> Items { get; set; }
    }
}

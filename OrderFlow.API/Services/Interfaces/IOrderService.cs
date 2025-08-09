using OrderFlow.API.DTOs;
using OrderFlow.API.Models;

namespace OrderFlow.API.Services.Interfaces
{
    public interface IOrderService
    
   {

        Task<int > CreateOrderAsync(CreateOrderDto orderDto);
        Task<OrderSummaryDto?> GetOrderSummaryByIdAsync(int id);
    }
}
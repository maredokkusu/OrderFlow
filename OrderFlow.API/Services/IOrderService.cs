using OrderFlow.API.DTOs;

namespace OrderFlow.API.Services
{
    public interface IOrderService
    {
        List<OrderDto> GetAllOrders();
    public OrderDto GetOrderById(int id);
        public OrderDto CreateOrder(CreateOrderDto newOrder);
    }
}
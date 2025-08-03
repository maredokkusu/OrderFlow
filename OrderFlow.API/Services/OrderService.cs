using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.DTOs;
using OrderFlow.API.Models;
namespace OrderFlow.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _Orders;
        public OrderService()
        {
            _Orders = new List<Order>
            {new Order{
                    Id = 1,
                    CustomerName = "Juan Rulfo",
                    TotalAmount = 1900.99m
                },{ new Order{
                    Id=2,
                    CustomerName="Juan Flores",
                    TotalAmount=100000.99m} }
            };
        }
        public List<OrderDto> GetAllOrders()
        {
            return _Orders.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerName = o.CustomerName,
                TotalAmount = o.TotalAmount
            }).ToList();
        }
        public OrderDto? GetOrderById(int id) {
            var order = _Orders.FirstOrDefault(o => o.Id == id);
            if (order == null) { return null; }
            return new OrderDto
            {
                Id = order.Id,
                CustomerName = order.CustomerName,
                TotalAmount = order.TotalAmount

            };

        }
        public OrderDto CreateOrder(CreateOrderDto newOrder) { 
            var order = new Order {
            Id =_Orders.Max(o => o.Id) + 1,
                ProductName = newOrder.ProductName,
                Quantity = newOrder.Quantity,
                OrderDate = DateTime.Now};
            _Orders.Add(order);
            return new OrderDto
            {
                Id = order.Id,
                ProductName = order.ProductName,
                Quantity = order.Quantity
            };

    }
         
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFlow.API.Data;
using OrderFlow.API.DTOs;
using OrderFlow.API.Models;
using OrderFlow.API.Services.Interfaces;
using System.Linq.Expressions;
namespace OrderFlow.API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context) {
            _context = context;
        }
        public async Task<int> CreateOrderAsync(CreateOrderDto orderDto)
        {
            var order = new Order
            {
                Customer = orderDto.Customer,
                Id = orderDto.Id,
                Date = orderDto.Date,
                CustomerId = orderDto.CustomerId,
                Items = orderDto.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order.Id;
        }
        public async Task<OrderSummaryDto?> GetOrderSummaryByIdAsync(int id)
        {
            var order = await _context.
                Orders.Include(o => o.Items)
                .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) { return null; }
            return new OrderSummaryDto
            {
                Id = order.Id,
                CustomerName = order.Customer.CustomerName,
                ProductName = order.Items.FirstOrDefault()?.Product?.ProductName ?? string.Empty,
                Quantity = order.Quantity,
                Items = order.Items.Select(o => new OrderItemSummaryDto
                {
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,  
                    ProductName = o.Product.ProductName,
                }).ToList()
            };
        }

    } 
}
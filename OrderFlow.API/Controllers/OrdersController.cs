using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.Models;
using OrderFlow.API.DTOs;
using OrderFlow.API.Services.Interfaces;

namespace OrderFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderservice)
        {
            _orderService = orderservice;
        }
        //Create a order made by the Client
        [HttpPost]
        public ActionResult<OrderSummaryDto> Create([FromBody] CreateOrderDto newOrder) {
            var createdOrder = _orderService.CreateOrderAsync(newOrder);
            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }
        // Get a order by Id
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            var order = _orderService.GetOrderSummaryByIdAsync(id);
            if (order == null) { return NotFound(); };
            return Ok(order);

        }
    }
}
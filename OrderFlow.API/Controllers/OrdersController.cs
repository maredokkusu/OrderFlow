using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderFlow.API.Models;
using OrderFlow.API.DTOs;
using OrderFlow.API.Services;

namespace OrderFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderservice)
        {
            _orderService =orderservice;
        }
        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            var order = _orderService.GetOrderById(id);
                if (order == null) { return NotFound(); };
            return Ok(order);

        }
        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);

        }
    }
}
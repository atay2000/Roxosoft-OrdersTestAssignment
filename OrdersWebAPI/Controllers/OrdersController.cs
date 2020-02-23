using Microsoft.AspNetCore.Mvc;
using OrdersWebAPI.Models;
using OrdersWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController([FromServices] IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _ordersService.GetAllOrders();            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Order order = _ordersService.GetOrderDetail(id);

            if (order == null)
            {
                return NotFound(new { error = $"Details for order with id: {id} not found" });
            }

            return Ok(order);
        }
    }
}

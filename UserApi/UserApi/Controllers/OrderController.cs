using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Models;
using UserApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService orderSevice)
        {
            _service = orderSevice;
        }

        // POST api/<OrderController>
        [HttpPost]
        public string Post([FromBody] OrderDTO orderDTO)
        {
            return _service.UpdateOrderTable(orderDTO);
        }
        [Route("orderDetail")]
        [HttpPost]
        public void Post([FromBody] List<CustomerPizzaDetailsDTO> pizza)
        {
            _service.UpdateOrderDetailTable(pizza);
        }

    }
}

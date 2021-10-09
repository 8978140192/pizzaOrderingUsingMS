using Microsoft.AspNetCore.Mvc;
using OrderApi.Models;
using OrderApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class orderController : ControllerBase
    {
        private readonly OrderService _service;

        public orderController(OrderService orderSevice)
        {
            _service = orderSevice;
        }




        // POST api/<orderController>
        [HttpPost]
        public string Post([FromBody] OrderDto orderDto)
        {
            return _service.UpdateOrderTable(orderDto);
        }
        [Route("orderDetail")]
        [HttpPost]
        public void Post([FromBody] List<CustomerPizzaDetailsDTO> pizza)
        {
             _service.UpdateOrderDetailTable(pizza);
        }



    }
}

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
    public class PizzaViewController : ControllerBase
    {
        private readonly PizzaViewService _service;

        public PizzaViewController(PizzaViewService pizzaViewSevice)
        {
            _service = pizzaViewSevice;
        }
        // GET: api/<EmployeController>
        [HttpGet]
        public Task<IEnumerable<PizzaViewDTO>> Get()
        {
            //return new string[] { "value1", "value2" };
            return _service.GetPizzaDetails();
        }

        //// GET api/<EmployeController>/5
        [HttpGet("{id}")]
        public Task<PizzaViewDTO> Get(string id)
        {
            return _service.GetPizzaDetailsById(id);
        }
    }
}

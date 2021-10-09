using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;
using PizzaApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        private readonly PizzaServices _service;

        public PizzaApiController(PizzaServices pizzaService)
        {
            _service = pizzaService;
        }
        // GET: api/<PizzaApiController>
        [HttpGet]
        public IEnumerable<PizzaDetails> Get()
        {
            return _service.GetAllPizzaDetails(); ;
        }

        // GET api/<PizzaApiController>/5
        [HttpGet("{id}")]
        public PizzaDetails Get(string id)
        {
            return _service.GetAllPizzaDetailsById(id);
        }

        

        

       
    }
}

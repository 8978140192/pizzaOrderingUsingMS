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
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService userSevice)
        {
            _service = userSevice;
        }
        

        
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            var userDTO = _service.Register(user);
            if (userDTO != null)
                return userDTO;
            return BadRequest("Not able to register");
        }

        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Get([FromBody] UserDTO user)
        {
            var userDTO = _service.Login(user);
            if (userDTO != null)
                return Ok(userDTO);
            return BadRequest("Not able to Login");
        }

       
        

    
    }
}

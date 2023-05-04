using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAuth.Models;
using ApiAuth.Repositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
    [ApiController]
    [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            var user = UserRepository.Get(model.UserName, model.Password);
            if (User == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerationToken(user);

            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }
    }
}
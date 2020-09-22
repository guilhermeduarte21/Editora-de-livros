using System;
using Editora.Service;
using Microsoft.AspNetCore.Mvc;

namespace Editora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private UsuarioService _usuarioService { get; set; }

        public UsuarioController(UsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;

        }


        [Route("Token")]
        [HttpPost]
        [RequireHttps]
        public IActionResult Token([FromBody] LoginRequest loginRequest)
        {
            var token = this._usuarioService.Login(loginRequest.Login, loginRequest.Senha);

            if (String.IsNullOrWhiteSpace(token))
            {
                return BadRequest("Login ou senha invalida");
            }

            return Ok(new
            {
                Token = token
            });
        }

    }

    public class LoginRequest
    {
        public String Login { get; set; }
        public String Senha { get; set; }
    }
}

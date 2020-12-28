using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromServices] DataContext context, [FromBody] Usuario model)
        {
            var Usuario = UsuarioRepository.Get(model.Nome, model.Senha, context);

            if (Usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenServices.GenerateToken(Usuario);
            Usuario.Senha = "";
            return new
            {
                Usuario = Usuario,
                token = token
            };
        }

        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Diretor")]
        public async Task<ActionResult<List<Usuario>>> Get([FromServices] DataContext context)
        {
            var Usuarios = await context.Usuarios.ToListAsync();
            return Usuarios;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Usuario>> Post
        ([FromServices] DataContext context,
        [FromBody] Usuario model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Usuarios.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
    }
}

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


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("v1/projetos")]
    public class ProjetosController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Projetos>>> Get([FromServices] DataContext context)
        {
            var Projetos = await context.Projeto.ToListAsync();
            return Projetos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Projetos>> Post
        ([FromServices] DataContext context,
        [FromBody] Projetos model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Projeto.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Projetos>> Delete([FromServices] DataContext context, int id)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lancamentoHoras = await context.LancamentoHora.Where(e => e.Projetos.Id == id).FirstOrDefaultAsync();

            if (lancamentoHoras != null)
            {
                return BadRequest("Projeto vinculado ao Lançamento " + lancamentoHoras.Id + " não pode ser removido");
            }
            else
            {
                var projeto = await context.Projeto
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Projeto.Remove(projeto);
                await context.SaveChangesAsync();

                return Ok("Removido com Sucesso");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Projetos>> Put(int id,
            [FromServices] DataContext context,
            [FromBody] Projetos model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var projeto = await context.Projeto
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            projeto.Nome_Projeto = model.Nome_Projeto;

            context.Projeto.Update(projeto);
            await context.SaveChangesAsync();

            return Ok("Projeto atualizado com Sucesso");
        }
    }
}

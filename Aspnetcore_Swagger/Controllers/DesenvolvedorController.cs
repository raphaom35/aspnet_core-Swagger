using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("v1/desenvolvedores")]
    public class DesenvolvedorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Desenvolvedor>>> Get([FromServices] DataContext context)
        {
            var Desenvolvedor = await context.Desenvolvedores.ToListAsync();
            return Desenvolvedor;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Desenvolvedor>> Post
        ([FromServices] DataContext context,
        [FromBody] Desenvolvedor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.Desenvolvedores.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Desenvolvedor>> Delete([FromServices] DataContext context, int id)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lancamentoHoras = await context.LancamentoHora.Where(e => e.Desenvolvedor.Id == id).FirstOrDefaultAsync();

            if (lancamentoHoras != null)
            {
                return BadRequest("Desenvolvedor vinculado ao Lançamento " + lancamentoHoras.Id + " não pode ser removido");
            }
            else
            {
                var desenvolvedor = await context.Desenvolvedores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                context.Desenvolvedores.Remove(desenvolvedor);
                await context.SaveChangesAsync();

                return Ok("Removido com Sucesso");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Desenvolvedor>> Put(int id,
            [FromServices] DataContext context,
            [FromBody] Desenvolvedor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var desenvolvedor = await context.Desenvolvedores
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            desenvolvedor.Nome_Desenvolvedor = model.Nome_Desenvolvedor;

            context.Desenvolvedores.Update(desenvolvedor);
            await context.SaveChangesAsync();

            return Ok("Desenvolvedor atualizado com Sucesso");
        }

    }
}

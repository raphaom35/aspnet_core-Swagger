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
    [Route("v1/lancamentoHoras")]
    public class LancamentoHorasController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<LancamentoHoras>>> Get([FromServices] DataContext context)
        {
            var LancamentoHoras = await context.LancamentoHora.Include(
                x => x.Projetos).Include(
                e => e.Desenvolvedor).ToListAsync();
            return Ok(LancamentoHoras);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<LancamentoHoras>> GetById([FromServices] DataContext context, int id)
        {
            var LancamentoHoras = await context.LancamentoHora
                .Include(x => x.Projetos)
                .Include(e => e.Desenvolvedor)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(LancamentoHoras);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Diretor")]
        public async Task<ActionResult<LancamentoHoras>> Delete([FromServices] DataContext context, int id)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lancamentoHoras = await context.LancamentoHora
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            context.LancamentoHora.Remove(lancamentoHoras);
            await context.SaveChangesAsync();

            return Ok("Removido com Sucesso");

        }

        [HttpPut("{id:int}")]
        [Authorize(Roles = "Diretor")]
        public async Task<ActionResult<LancamentoHoras>> Put(int id,
            [FromServices] DataContext context,
            [FromBody] LancamentoHoras model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var lancamentoHoras = await context.LancamentoHora
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);

            lancamentoHoras.data_inicio = model.data_inicio != null ? model.data_inicio : lancamentoHoras.data_inicio;
            lancamentoHoras.data_fim = model.data_fim != null ? model.data_fim : lancamentoHoras.data_fim;

            context.LancamentoHora.Update(lancamentoHoras);
            await context.SaveChangesAsync();

            return Ok("Lançamento atualizado com Sucesso");
        }

        [HttpGet]
        [Route("ranking")]
        [Authorize(Roles = "Diretor")]
        public async Task<List<Ranking>> Ranking([FromServices] DataContext context)
        {
            var lancamentos = await context.LancamentoHora
                .AsNoTracking()
                .Include(e => e.Desenvolvedor)
                .Include(e => e.Projetos)
                .ToListAsync();

            var rankings = new List<Ranking>();
            foreach (var item in lancamentos)
            {
                if (rankings.Any(e => e.DesenvolvedorId == item.Desenvolvedor.Id))
                {
                    var rankAtualizado = rankings.First(e => e.DesenvolvedorId == item.Desenvolvedor.Id);
                    rankAtualizado.HorasTrabalhadasNaSemana = rankAtualizado.HorasTrabalhadasNaSemana + item.data_fim.Hour - item.data_inicio.Hour;
                }
                else
                {
                    //Novo Objeto para adicionar na lista
                    var colocacaoNaSemana = new Ranking
                    {
                        DesenvolvedorId = item.Desenvolvedor.Id,
                        HorasTrabalhadasNaSemana = item.data_fim.Hour - item.data_inicio.Hour
                    };
                    rankings.Add(colocacaoNaSemana);
                }
            }
            return rankings.OrderByDescending(it => it.HorasTrabalhadasNaSemana).Take(5).ToList();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<LancamentoHoras>> Post
        ([FromServices] DataContext context,
        [FromBody] LancamentoHoras model)
        {
            if (DateTime.Compare(model.data_inicio, model.data_fim) >= 0)
            {
                return BadRequest("Hora Inicio não pode ser maior ou igual a hora fim");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            context.LancamentoHora.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }

    }
}
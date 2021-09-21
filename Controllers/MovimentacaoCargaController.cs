using API.DataContexto;
using Enumeradores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route(nameof(MovimentacaoCarga))]
    public class MovimentacaoCargaController : ControllerBase
    {
        private static Contexto_SQL _contexto;
        public MovimentacaoCargaController([FromServices] Contexto_SQL contextoSQL)
        {
            _contexto = contextoSQL;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<MovimentacaoCarga>> Get(int id)
        {
            MovimentacaoCarga movimentacao = _contexto.MovimentacaoCarga.FirstOrDefault(c => c.ID == id);

            if (movimentacao == null)
                return NotFound(MensagemCliente.MovimentacaoNaoEncontrada());

            return Ok(movimentacao);
        }

        [HttpGet]
        public async Task<ActionResult<List<MovimentacaoCarga>>> Get()
        {
            List<MovimentacaoCarga> listaMovimentacoes = await _contexto.MovimentacaoCarga.AsNoTracking().ToListAsync();

            return Ok(listaMovimentacoes);
        }

        [HttpPost]
        public async Task<ActionResult<MovimentacaoCarga>> Post([FromBody] MovimentacaoCarga movimentacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _contexto.MovimentacaoCarga.Add(movimentacao);
                await _contexto.SaveChangesAsync();
            }
            catch (DbException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(movimentacao);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<MovimentacaoCarga>> Put(int id, [FromBody] MovimentacaoCarga movimentacao)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (movimentacao.ID != id)
                return NotFound(MensagemCliente.MovimentacaoNaoEncontrada());
            try
            {
                _contexto.Entry<MovimentacaoCarga>(movimentacao).State = EntityState.Modified;
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            catch (DbException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(movimentacao);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<MovimentacaoCarga>> Delete(int id)
        {
            MovimentacaoCarga movimentacao = await _contexto.MovimentacaoCarga.FirstOrDefaultAsync(c => c.ID == id);

            if (movimentacao == null)
                return NotFound(MensagemCliente.MovimentacaoNaoEncontrada());
            try
            {
                _contexto.MovimentacaoCarga.Remove(movimentacao);
                await _contexto.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }
            catch (DbException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(movimentacao);
        }
    }
}

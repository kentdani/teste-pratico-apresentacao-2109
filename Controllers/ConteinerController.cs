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
    [Route(nameof(Conteiner))]
    public class ConteinerController : ControllerBase
    {
        private static Contexto_SQL _contexto;
        public ConteinerController([FromServices] Contexto_SQL contextoSQL)
        {
            _contexto = contextoSQL;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Conteiner>> Get(int id)
        {
            Conteiner conteiner = _contexto.Conteiner.FirstOrDefault(c => c.ID == id);

            if (conteiner == null)
                return NotFound(MensagemCliente.ConteinerNaoEncontrado());

            return Ok(conteiner);
        }

        [HttpGet]
        public async Task<ActionResult<List<Conteiner>>> Get()
        {
            List<Conteiner> listaConteiner = await _contexto.Conteiner.AsNoTracking().ToListAsync();

            return Ok(listaConteiner);
        }

        [HttpPost]
        public async Task<ActionResult<Conteiner>> Post([FromBody] Conteiner conteiner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _contexto.Conteiner.Add(conteiner);
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
            return Ok(conteiner);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Conteiner>> Put(int id, [FromBody] Conteiner conteiner)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (conteiner.ID != id)
                return NotFound(MensagemCliente.ConteinerNaoEncontrado());
            try
            {
                _contexto.Entry<Conteiner>(conteiner).State = EntityState.Modified;
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
            return Ok(conteiner);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Conteiner>> Delete(int id)
        {
            Conteiner conteiner = await _contexto.Conteiner.FirstOrDefaultAsync(c => c.ID == id);

            if (conteiner == null)
                return NotFound(MensagemCliente.ConteinerNaoEncontrado());
            try
            {
                _contexto.Conteiner.Remove(conteiner);
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
            return Ok(conteiner);
        }
    }
}

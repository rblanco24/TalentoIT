using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TalentoIT.Data;
using TalentoIT.Data.Entities;

namespace TalentoIT.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly DataContext _context;

        public CandidatoController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CandidatoEntities
        [HttpGet]
        public IEnumerable<CandidatoEntity> GetCandidato()
        {
            return _context.Candidato;
        }

        // GET: api/CandidatoEntities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidatoEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidatoEntity = await _context.Candidato.FindAsync(id);

            if (candidatoEntity == null)
            {
                return NotFound();
            }

            return Ok(candidatoEntity);
        }

        // PUT: api/CandidatoEntities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidatoEntity([FromRoute] int id, [FromBody] CandidatoEntity candidatoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != candidatoEntity.id)
            {
                return BadRequest();
            }

            _context.Entry(candidatoEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CandidatoEntities
        [HttpPost]
        public async Task<IActionResult> PostCandidatoEntity([FromBody] CandidatoEntity candidatoEntity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Candidato.Add(candidatoEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCandidatoEntity", new { id = candidatoEntity.id }, candidatoEntity);
        }

        // DELETE: api/CandidatoEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidatoEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidatoEntity = await _context.Candidato.FindAsync(id);
            if (candidatoEntity == null)
            {
                return NotFound();
            }

            _context.Candidato.Remove(candidatoEntity);
            await _context.SaveChangesAsync();

            return Ok(candidatoEntity);
        }

        private bool CandidatoEntityExists(int id)
        {
            return _context.Candidato.Any(e => e.id == id);
        }
    }
}
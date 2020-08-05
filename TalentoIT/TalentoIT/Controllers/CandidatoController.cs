using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TalentoIT.Data;
using TalentoIT.Data.Entities;

namespace TalentoIT.Controllers
{
    public class CandidatoController : Controller
    {
        private readonly DataContext _context;

        public CandidatoController(DataContext context)
        {
            _context = context;
        }

        // GET: Candidato
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidato.ToListAsync());
        }

        // GET: Candidato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoEntity = await _context.Candidato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatoEntity == null)
            {
                return NotFound();
            }

            return View(candidatoEntity);
        }

        // GET: Candidato/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CandidatoEntity candidatoEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidatoEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatoEntity);
        }

        // GET: Candidato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoEntity = await _context.Candidato.FindAsync(id);
            if (candidatoEntity == null)
            {
                return NotFound();
            }
            return View(candidatoEntity);
        }

        // POST: Candidato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CandidatoEntity candidatoEntity)
        {
            if (id != candidatoEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatoEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoEntityExists(candidatoEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(candidatoEntity);
        }

        // GET: Candidato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoEntity = await _context.Candidato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidatoEntity == null)
            {
                return NotFound();
            }

            return View(candidatoEntity);
        }

        // POST: Candidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidatoEntity = await _context.Candidato.FindAsync(id);
            _context.Candidato.Remove(candidatoEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoEntityExists(int id)
        {
            return _context.Candidato.Any(e => e.Id == id);
        }
    }
}

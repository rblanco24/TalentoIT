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
    public class EntrevistaController : Controller
    {
        private readonly DataContext _context;

        public EntrevistaController(DataContext context)
        {
            _context = context;
        }

        // GET: Entrevista
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entrevista.ToListAsync());
        }

        // GET: Entrevista/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevistaEntity = await _context.Entrevista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrevistaEntity == null)
            {
                return NotFound();
            }

            return View(entrevistaEntity);
        }

        // GET: Entrevista/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entrevista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaHora,Tipo")] EntrevistaEntity entrevistaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrevistaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entrevistaEntity);
        }

        // GET: Entrevista/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevistaEntity = await _context.Entrevista.FindAsync(id);
            if (entrevistaEntity == null)
            {
                return NotFound();
            }
            return View(entrevistaEntity);
        }

        // POST: Entrevista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaHora,Tipo")] EntrevistaEntity entrevistaEntity)
        {
            if (id != entrevistaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrevistaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrevistaEntityExists(entrevistaEntity.Id))
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
            return View(entrevistaEntity);
        }

        // GET: Entrevista/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrevistaEntity = await _context.Entrevista
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entrevistaEntity == null)
            {
                return NotFound();
            }

            return View(entrevistaEntity);
        }

        // POST: Entrevista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrevistaEntity = await _context.Entrevista.FindAsync(id);
            _context.Entrevista.Remove(entrevistaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrevistaEntityExists(int id)
        {
            return _context.Entrevista.Any(e => e.Id == id);
        }
    }
}

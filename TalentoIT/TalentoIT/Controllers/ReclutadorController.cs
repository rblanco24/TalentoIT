using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TalentoIT.Data;
using TalentoIT.Data.Entities;

namespace TalentoIT.Controllers
{
    public class ReclutadorController : Controller
    {
        private readonly DataContext _context;

        public ReclutadorController(DataContext context)
        {
            _context = context;
        }

        // GET: Reclutador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reclutador.ToListAsync());
        }

        // GET: Reclutador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclutadorEntity = await _context.Reclutador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclutadorEntity == null)
            {
                return NotFound();
            }

            return View(reclutadorEntity);
        }

        // GET: Reclutador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reclutador/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] ReclutadorEntity reclutadorEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclutadorEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reclutadorEntity);
        }

        // GET: Reclutador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclutadorEntity = await _context.Reclutador.FindAsync(id);
            if (reclutadorEntity == null)
            {
                return NotFound();
            }
            return View(reclutadorEntity);
        }

        // POST: Reclutador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] ReclutadorEntity reclutadorEntity)
        {
            if (id != reclutadorEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclutadorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclutadorEntityExists(reclutadorEntity.Id))
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
            return View(reclutadorEntity);
        }

        // GET: Reclutador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclutadorEntity = await _context.Reclutador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reclutadorEntity == null)
            {
                return NotFound();
            }

            return View(reclutadorEntity);
        }

        // POST: Reclutador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclutadorEntity = await _context.Reclutador.FindAsync(id);
            _context.Reclutador.Remove(reclutadorEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclutadorEntityExists(int id)
        {
            return _context.Reclutador.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult submit(string LbTecnologia)
        {
            return RedirectToAction("Index", "Tecnologia", new { parametro = LbTecnologia });
        }
    }
}

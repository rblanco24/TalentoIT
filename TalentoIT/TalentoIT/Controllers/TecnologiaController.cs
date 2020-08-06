using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TalentoIT.Data;
using TalentoIT.Data.Entities;

namespace TalentoIT.Controllers
{
    public class TecnologiaController : Controller
    {
        private readonly DataContext _context;

        public TecnologiaController(DataContext context)
        {
            _context = context;
        }

        // GET: Tecnologia
        public async Task<IActionResult> Index(string parametro)
        {
            try
            {
                if (parametro != null)
                {
                    return View(await _context.TecnologiaEntity.Where(w => w.TipoTecnologia == parametro).OrderBy(t => t.TipoTecnologia).ToListAsync());
                }
                else
                {
                    return View(await _context.TecnologiaEntity.OrderBy(t => t.TipoTecnologia).ToListAsync());
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        // GET: Tecnologia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity.FindAsync(id);

            if (tecnologiaEntity == null)
            {
                return NotFound();
            }

            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoTecnologia,Nombre")] TecnologiaEntity tecnologiaEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tecnologiaEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity.FindAsync(id);
            if (tecnologiaEntity == null)
            {
                return NotFound();
            }
            return View(tecnologiaEntity);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoTecnologia,Nombre")] TecnologiaEntity tecnologiaEntity)
        {
            if (id != tecnologiaEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tecnologiaEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TecnologiaEntityExists(tecnologiaEntity.Id))
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
            return View(tecnologiaEntity);
        }

        // GET: Tecnologia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tecnologiaEntity = await _context.TecnologiaEntity.FindAsync(id);
            if (tecnologiaEntity == null)
            {
                return NotFound();
            }

            _context.TecnologiaEntity.Remove(tecnologiaEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TecnologiaEntityExists(int id)
        {
            return _context.TecnologiaEntity.Any(e => e.Id == id);
        }

        [HttpPost]
        public IActionResult submit(string parametro)
        {
            return RedirectToAction("Index", "Reclutador", new { parametro = "" });
        }
    }
}

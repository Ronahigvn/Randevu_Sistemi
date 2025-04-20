using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandevuSistemi.Data;
using RandevuSistemi.Models;
using System.Threading.Tasks;

namespace RandevuSistemi.Controllers
{
    public class RandevularController : Controller
    {
        private readonly UygulamaDbContext _context;

        // Constructor
        public RandevularController(UygulamaDbContext context)
        {
            _context = context;
        }

        // Index Action (Listeleme)
        public async Task<IActionResult> Index()
        {
            var randevular = await _context.Randevular.ToListAsync();
            return View("~/Views/Randevular/Index.cshtml", randevular);
        }

        // GET: Randevular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Randevular/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(randevu);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Randevu başarıyla eklendi!";
                return RedirectToAction(nameof(Index)); // Success, redirect to Index page
            }

            return View(randevu); // If validation fails, return the same page
        }

        // GET: Randevular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu == null) return NotFound();

            return View(randevu);
        }

        // POST: Randevular/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Randevu randevu)
        {
            if (id != randevu.RandevuId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(randevu);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Randevular.Any(e => e.RandevuId == id))
                        return NotFound();
                    else
                        throw;
                }
            }

            return View(randevu);
        }
        // GET: Randevular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var randevu = await _context.Randevular
                .FirstOrDefaultAsync(m => m.RandevuId == id);

            if (randevu == null)
                return NotFound();

            return View(randevu);
        }

        // POST: Randevular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var randevu = await _context.Randevular.FindAsync(id);
            if (randevu != null)
            {
                _context.Randevular.Remove(randevu);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        private bool RandevuExists(int id)
        {
            return _context.Randevular.Any(e => e.RandevuId == id);
        }

        public IActionResult Test()
        {
            return View("Randevular/Test");
        }
    }
}
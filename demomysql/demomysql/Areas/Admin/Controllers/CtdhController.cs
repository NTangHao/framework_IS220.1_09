using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demomysql.Models;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CtdhController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public CtdhController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Ctdh
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Ctdhs.Include(c => c.MadonhangNavigation).Include(c => c.MaspNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Ctdh/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdh = await _context.Ctdhs
                .Include(c => c.MadonhangNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (ctdh == null)
            {
                return NotFound();
            }

            return View(ctdh);
        }

        // GET: Admin/Ctdh/Create
        public IActionResult Create()
        {
            ViewData["Madonhang"] = new SelectList(_context.Donhangs, "Madonhang", "Madonhang");
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp");
            return View();
        }

        // POST: Admin/Ctdh/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Madonhang,Dongia,Soluong")] Ctdh ctdh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ctdh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Madonhang"] = new SelectList(_context.Donhangs, "Madonhang", "Madonhang", ctdh.Madonhang);
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctdh.Masp);
            return View(ctdh);
        }

        // GET: Admin/Ctdh/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdh = await _context.Ctdhs.FindAsync(id);
            if (ctdh == null)
            {
                return NotFound();
            }
            ViewData["Madonhang"] = new SelectList(_context.Donhangs, "Madonhang", "Madonhang", ctdh.Madonhang);
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctdh.Masp);
            return View(ctdh);
        }

        // POST: Admin/Ctdh/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masp,Madonhang,Dongia,Soluong")] Ctdh ctdh)
        {
            if (id != ctdh.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ctdh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CtdhExists(ctdh.Masp))
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
            ViewData["Madonhang"] = new SelectList(_context.Donhangs, "Madonhang", "Madonhang", ctdh.Madonhang);
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", ctdh.Masp);
            return View(ctdh);
        }

        // GET: Admin/Ctdh/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ctdh = await _context.Ctdhs
                .Include(c => c.MadonhangNavigation)
                .Include(c => c.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (ctdh == null)
            {
                return NotFound();
            }

            return View(ctdh);
        }

        // POST: Admin/Ctdh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ctdh = await _context.Ctdhs.FindAsync(id);
            _context.Ctdhs.Remove(ctdh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CtdhExists(int id)
        {
            return _context.Ctdhs.Any(e => e.Masp == id);
        }
    }
}

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
    public class BinhluanController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public BinhluanController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Binhluan
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Binhluans.Include(b => b.ManguoidungNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Binhluan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.ManguoidungNavigation)
                .FirstOrDefaultAsync(m => m.Mabinhluan == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // GET: Admin/Binhluan/Create
        public IActionResult Create()
        {
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung");
            return View();
        }

        // POST: Admin/Binhluan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Mabinhluan,Manguoidung,Noidung,Ngaytao")] Binhluan binhluan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhluan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", binhluan.Manguoidung);
            return View(binhluan);
        }

        // GET: Admin/Binhluan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans.FindAsync(id);
            if (binhluan == null)
            {
                return NotFound();
            }
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", binhluan.Manguoidung);
            return View(binhluan);
        }

        // POST: Admin/Binhluan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Mabinhluan,Manguoidung,Noidung,Ngaytao")] Binhluan binhluan)
        {
            if (id != binhluan.Mabinhluan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhluan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhluanExists(binhluan.Mabinhluan))
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
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", binhluan.Manguoidung);
            return View(binhluan);
        }

        // GET: Admin/Binhluan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhluan = await _context.Binhluans
                .Include(b => b.ManguoidungNavigation)
                .FirstOrDefaultAsync(m => m.Mabinhluan == id);
            if (binhluan == null)
            {
                return NotFound();
            }

            return View(binhluan);
        }

        // POST: Admin/Binhluan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhluan = await _context.Binhluans.FindAsync(id);
            _context.Binhluans.Remove(binhluan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhluanExists(int id)
        {
            return _context.Binhluans.Any(e => e.Mabinhluan == id);
        }
    }
}

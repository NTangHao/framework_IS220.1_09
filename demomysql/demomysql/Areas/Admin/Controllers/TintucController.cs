using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demomysql.Models;
using demomysql.Helper;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TintucController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public TintucController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Tintuc
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Tintucs.Include(t => t.ManguoidungNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Tintuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .Include(t => t.ManguoidungNavigation)
                .FirstOrDefaultAsync(m => m.Matintuc == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // GET: Admin/Tintuc/Create
        public IActionResult Create()
        {
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung");
            return View();
        }

        // POST: Admin/Tintuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Matintuc,Manguoidung,Tieude,Noidung,Ngaydang,Ngaysua,Hinhanh")] Tintuc tintuc, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (ModelState.IsValid)
            {

                if (hinhanh != null)
                {

                    tintuc.Hinhanh = await Utilities.UploadFile(hinhanh, @"tintucs");
                }
                if (string.IsNullOrEmpty(tintuc.Hinhanh))
                {
                    tintuc.Hinhanh = "default.jpg";
                }
                tintuc.Ngaydang = DateTime.Now;
                _context.Add(tintuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", tintuc.Manguoidung);
            return View(tintuc);
        }

        // GET: Admin/Tintuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs.FindAsync(id);
            if (tintuc == null)
            {
                return NotFound();
            }
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", tintuc.Manguoidung);
            return View(tintuc);
        }

        // POST: Admin/Tintuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Matintuc,Manguoidung,Tieude,Noidung,Ngaydang,Ngaysua,Hinhanh")] Tintuc tintuc, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (id != tintuc.Matintuc)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (hinhanh != null)
                    {

                        tintuc.Hinhanh = await Utilities.UploadFile(hinhanh, @"tintucs");
                    }
                    if (string.IsNullOrEmpty(tintuc.Hinhanh))
                    {
                        tintuc.Hinhanh = "default.jpg";
                    }
                    _context.Update(tintuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TintucExists(tintuc.Matintuc))
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
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", tintuc.Manguoidung);
            return View(tintuc);
        }

        // GET: Admin/Tintuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tintuc = await _context.Tintucs
                .Include(t => t.ManguoidungNavigation)
                .FirstOrDefaultAsync(m => m.Matintuc == id);
            if (tintuc == null)
            {
                return NotFound();
            }

            return View(tintuc);
        }

        // POST: Admin/Tintuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tintuc = await _context.Tintucs.FindAsync(id);
            _context.Tintucs.Remove(tintuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TintucExists(int id)
        {
            return _context.Tintucs.Any(e => e.Matintuc == id);
        }
    }
}

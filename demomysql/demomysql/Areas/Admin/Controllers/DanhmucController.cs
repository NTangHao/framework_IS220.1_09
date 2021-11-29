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
    public class DanhmucController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public DanhmucController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Danhmuc
        public async Task<IActionResult> Index()
        {
            return View(await _context.Danhmucs.ToListAsync());
        }

        // GET: Admin/Danhmuc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmucs
                .FirstOrDefaultAsync(m => m.Madm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Danhmuc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madm,Tendm,Mota,Hinhanh")] Danhmuc danhmuc, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (ModelState.IsValid)
            {
                if (hinhanh != null)
                {

                    danhmuc.Hinhanh = await Utilities.UploadFile(hinhanh, @"danhmucs");
                }
                if (string.IsNullOrEmpty(danhmuc.Hinhanh))
                {
                    danhmuc.Hinhanh = "default.jpg";
                }
               
                _context.Add(danhmuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmucs.FindAsync(id);
            if (danhmuc == null)
            {
                return NotFound();
            }
            return View(danhmuc);
        }

        // POST: Admin/Danhmuc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madm,Tendm,Mota,Hinhanh")] Danhmuc danhmuc, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (id != danhmuc.Madm)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (hinhanh != null)
                    {

                        danhmuc.Hinhanh = await Utilities.UploadFile(hinhanh, @"danhmucs");
                    }
                    if (string.IsNullOrEmpty(danhmuc.Hinhanh))
                    {
                        danhmuc.Hinhanh = "default.jpg";
                    }
                    _context.Update(danhmuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DanhmucExists(danhmuc.Madm))
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
            return View(danhmuc);
        }

        // GET: Admin/Danhmuc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var danhmuc = await _context.Danhmucs
                .FirstOrDefaultAsync(m => m.Madm == id);
            if (danhmuc == null)
            {
                return NotFound();
            }

            return View(danhmuc);
        }

        // POST: Admin/Danhmuc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var danhmuc = await _context.Danhmucs.FindAsync(id);
            _context.Danhmucs.Remove(danhmuc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DanhmucExists(int id)
        {
            return _context.Danhmucs.Any(e => e.Madm == id);
        }
    }
}

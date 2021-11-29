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
    public class GiaohangController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public GiaohangController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Giaohang
        public async Task<IActionResult> Index()
        {
            return View(await _context.Giaohangs.ToListAsync());
        }

        // GET: Admin/Giaohang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaohang = await _context.Giaohangs
                .FirstOrDefaultAsync(m => m.Magiaohang == id);
            if (giaohang == null)
            {
                return NotFound();
            }

            return View(giaohang);
        }

        // GET: Admin/Giaohang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Giaohang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Magiaohang,Tennguoigiao,Ngaygiao,Sdt,Xacnhan")] Giaohang giaohang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giaohang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giaohang);
        }

        // GET: Admin/Giaohang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaohang = await _context.Giaohangs.FindAsync(id);
            if (giaohang == null)
            {
                return NotFound();
            }
            return View(giaohang);
        }

        // POST: Admin/Giaohang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Magiaohang,Tennguoigiao,Ngaygiao,Sdt,Xacnhan")] Giaohang giaohang)
        {
            if (id != giaohang.Magiaohang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giaohang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiaohangExists(giaohang.Magiaohang))
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
            return View(giaohang);
        }

        // GET: Admin/Giaohang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giaohang = await _context.Giaohangs
                .FirstOrDefaultAsync(m => m.Magiaohang == id);
            if (giaohang == null)
            {
                return NotFound();
            }

            return View(giaohang);
        }

        // POST: Admin/Giaohang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giaohang = await _context.Giaohangs.FindAsync(id);
            _context.Giaohangs.Remove(giaohang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiaohangExists(int id)
        {
            return _context.Giaohangs.Any(e => e.Magiaohang == id);
        }
    }
}

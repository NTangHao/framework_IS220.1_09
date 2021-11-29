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
    public class VaitronguoidungController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public VaitronguoidungController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Vaitronguoidung
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vaitronguoidungs.ToListAsync());
        }

        // GET: Admin/Vaitronguoidung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaitronguoidung = await _context.Vaitronguoidungs
                .FirstOrDefaultAsync(m => m.Maquyen == id);
            if (vaitronguoidung == null)
            {
                return NotFound();
            }

            return View(vaitronguoidung);
        }

        // GET: Admin/Vaitronguoidung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Vaitronguoidung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maquyen,Tenquyen")] Vaitronguoidung vaitronguoidung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaitronguoidung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaitronguoidung);
        }

        // GET: Admin/Vaitronguoidung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaitronguoidung = await _context.Vaitronguoidungs.FindAsync(id);
            if (vaitronguoidung == null)
            {
                return NotFound();
            }
            return View(vaitronguoidung);
        }

        // POST: Admin/Vaitronguoidung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maquyen,Tenquyen")] Vaitronguoidung vaitronguoidung)
        {
            if (id != vaitronguoidung.Maquyen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaitronguoidung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaitronguoidungExists(vaitronguoidung.Maquyen))
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
            return View(vaitronguoidung);
        }

        // GET: Admin/Vaitronguoidung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaitronguoidung = await _context.Vaitronguoidungs
                .FirstOrDefaultAsync(m => m.Maquyen == id);
            if (vaitronguoidung == null)
            {
                return NotFound();
            }

            return View(vaitronguoidung);
        }

        // POST: Admin/Vaitronguoidung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaitronguoidung = await _context.Vaitronguoidungs.FindAsync(id);
            _context.Vaitronguoidungs.Remove(vaitronguoidung);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaitronguoidungExists(int id)
        {
            return _context.Vaitronguoidungs.Any(e => e.Maquyen == id);
        }
    }
}

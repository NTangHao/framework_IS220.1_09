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
    public class AnhthemController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public AnhthemController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Anhthem
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Anhthems.Include(a => a.MaspNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Anhthem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhthem = await _context.Anhthems
                .Include(a => a.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Maanh == id);
            if (anhthem == null)
            {
                return NotFound();
            }

            return View(anhthem);
        }

        // GET: Admin/Anhthem/Create
        public IActionResult Create()
        {
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Tensp");
            return View();
        }

        // POST: Admin/Anhthem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maanh,Masp,Linkanh,Ngaytao")] Anhthem anhthem, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (ModelState.IsValid)
            {
                if (hinhanh != null)
                {

                    anhthem.Linkanh = await Utilities.UploadFile(hinhanh, @"hinhanhthems");
                }
                if (string.IsNullOrEmpty(anhthem.Linkanh))
                {
                    anhthem.Linkanh = "default.jpg";
                }
                anhthem.Ngaytao = DateTime.Now;

                _context.Add(anhthem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
                
            
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", anhthem.Masp);
            return View(anhthem);
        }

        // GET: Admin/Anhthem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhthem = await _context.Anhthems.FindAsync(id);
            if (anhthem == null)
            {
                return NotFound();
            }
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", anhthem.Masp);
            return View(anhthem);
        }

        // POST: Admin/Anhthem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maanh,Masp,Linkanh,Ngaytao")] Anhthem anhthem, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (id != anhthem.Maanh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (hinhanh != null)
                    {

                        anhthem.Linkanh = await Utilities.UploadFile(hinhanh, @"hinhanhthems");
                    }
                    if (string.IsNullOrEmpty(anhthem.Linkanh))
                    {
                        anhthem.Linkanh = "default.jpg";
                    }
                    
                    _context.Update(anhthem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnhthemExists(anhthem.Maanh))
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
            ViewData["Masp"] = new SelectList(_context.Sanphams, "Masp", "Masp", anhthem.Masp);
            return View(anhthem);
        }

        // GET: Admin/Anhthem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anhthem = await _context.Anhthems
                .Include(a => a.MaspNavigation)
                .FirstOrDefaultAsync(m => m.Maanh == id);
            if (anhthem == null)
            {
                return NotFound();
            }

            return View(anhthem);
        }

        // POST: Admin/Anhthem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var anhthem = await _context.Anhthems.FindAsync(id);
            _context.Anhthems.Remove(anhthem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnhthemExists(int id)
        {
            return _context.Anhthems.Any(e => e.Maanh == id);
        }
    }
}

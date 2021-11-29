using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demomysql.Models;
using demomysql.Helper;
using System.IO;
namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanphamController : BaseController
    {
        private readonly linhkienchinhthucContext _context;

        public SanphamController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        // GET: Admin/Sanpham
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Sanphams.Include(s => s.MadmNavigation).Include(s => s.MathuonghieuNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Sanpham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.MadmNavigation)
                .Include(s => s.MathuonghieuNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // GET: Admin/Sanpham/Create
        public IActionResult Create()
        {
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Tendm");
            ViewData["Mathuonghieu"] = new SelectList(_context.Thuonghieus, "Mathuonghieu", "Tenthuonghieu");
            return View();
        }

        // POST: Admin/Sanpham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Masp,Mathuonghieu,Madm,Tensp,Chitiet,Dongia,Giakm,Baohanh,Luotxem,Ngaydang,Soluong,Banchay,Hinhanh,Tinhtrangsp")] Sanpham sanpham,Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (ModelState.IsValid)
            {

               
                if (hinhanh!=null)
                {
                   
                    sanpham.Hinhanh = await Utilities.UploadFile(hinhanh, @"sanphams");
                }
                if (string.IsNullOrEmpty(sanpham.Hinhanh)) 
                {
                    sanpham.Hinhanh = "default.jpg";
                }
                sanpham.Ngaydang = DateTime.Now;
               
                _context.Add(sanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm", sanpham.Madm);
            ViewData["Mathuonghieu"] = new SelectList(_context.Thuonghieus, "Mathuonghieu", "Mathuonghieu", sanpham.Mathuonghieu);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams.FindAsync(id);
            if (sanpham == null)
            {
                return NotFound();
            }
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Tendm");
            ViewData["Mathuonghieu"] = new SelectList(_context.Thuonghieus, "Mathuonghieu", "Tenthuonghieu");
            return View(sanpham);
        }

        // POST: Admin/Sanpham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Masp,Mathuonghieu,Madm,Tensp,Chitiet,Dongia,Giakm,Baohanh,Luotxem,Ngaydang,Soluong,Banchay,Hinhanh,Tinhtrangsp")] Sanpham sanpham, Microsoft.AspNetCore.Http.IFormFile hinhanh)
        {
            if (id != sanpham.Masp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   // sanpham.Tensp = Utilities.ToTitleCase(sanpham.Tensp);
                    if (hinhanh != null)
                    {
                        //string extension = Path.GetExtension(hinhanh.FileName);
                        //string image = Utilities.SEOUrl(sanpham.Tensp) + extension;
                        //sanpham.Hinhanh = await Utilities.UploadFile(hinhanh, @"sanphams", image.ToLower());
                        sanpham.Hinhanh = await Utilities.UploadFile(hinhanh, @"sanphams");
                   }
                   

                    _context.Update(sanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanphamExists(sanpham.Masp))
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
            ViewData["Madm"] = new SelectList(_context.Danhmucs, "Madm", "Madm", sanpham.Madm);
            ViewData["Mathuonghieu"] = new SelectList(_context.Thuonghieus, "Mathuonghieu", "Mathuonghieu", sanpham.Mathuonghieu);
            return View(sanpham);
        }

        // GET: Admin/Sanpham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanpham = await _context.Sanphams
                .Include(s => s.MadmNavigation)
                .Include(s => s.MathuonghieuNavigation)
                .FirstOrDefaultAsync(m => m.Masp == id);
            if (sanpham == null)
            {
                return NotFound();
            }

            return View(sanpham);
        }

        // POST: Admin/Sanpham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanpham = await _context.Sanphams.FindAsync(id);
            _context.Sanphams.Remove(sanpham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanphamExists(int id)
        {
            return _context.Sanphams.Any(e => e.Masp == id);
        }
    }
}

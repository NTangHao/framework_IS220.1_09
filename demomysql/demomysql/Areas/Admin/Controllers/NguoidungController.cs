using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demomysql.Models;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NguoidungController : BaseController
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public NguoidungController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Admin/Nguoidung
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Nguoidungs.Include(n => n.MadanhgiaNavigation).Include(n => n.MaquyenNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
            
        }

        // GET: Admin/Nguoidung/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidungs
                .Include(n => n.MadanhgiaNavigation)
                .Include(n => n.MaquyenNavigation)
                .FirstOrDefaultAsync(m => m.Manguoidung == id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return View(nguoidung);
        }

        // GET: Admin/Nguoidung/Create
        public IActionResult Create()
        {
            ViewData["Madanhgia"] = new SelectList(_context.Danhgia, "Madanhgia", "Madanhgia");
            ViewData["Maquyen"] = new SelectList(_context.Vaitronguoidungs, "Maquyen", "Maquyen");
            return View();
        }

        // POST: Admin/Nguoidung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Manguoidung,Madanhgia,Maquyen,Username,Password,PasswordReset,Hoten,Ngaysinh,Email,Ngaytao,Ngaysua,Vaitro,Trangthai")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoidung);
                await _context.SaveChangesAsync();
                _notyfService.Success("Tạo mới thành công");
                return RedirectToAction("Index");

            }
            ViewData["Madanhgia"] = new SelectList(_context.Danhgia, "Madanhgia", "Madanhgia", nguoidung.Madanhgia);
            ViewData["Maquyen"] = new SelectList(_context.Vaitronguoidungs, "Maquyen", "Maquyen", nguoidung.Maquyen);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidung/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidungs.FindAsync(id);

            if (nguoidung == null)
            {
                return NotFound();
            }
            ViewData["Madanhgia"] = new SelectList(_context.Danhgia, "Madanhgia", "Madanhgia", nguoidung.Madanhgia);
            ViewData["Maquyen"] = new SelectList(_context.Vaitronguoidungs, "Maquyen", "Maquyen", nguoidung.Maquyen);
            return View(nguoidung);
        }

        // POST: Admin/Nguoidung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Manguoidung,Madanhgia,Maquyen,Username,Password,PasswordReset,Hoten,Ngaysinh,Email,Ngaytao,Ngaysua,Vaitro,Trangthai")] Nguoidung nguoidung)
        {
            if (id != nguoidung.Manguoidung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoidung);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật thành công");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoidungExists(nguoidung.Manguoidung))
                    {
                        _notyfService.Error("Không tìm thấy");
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Madanhgia"] = new SelectList(_context.Danhgia, "Madanhgia", "Madanhgia", nguoidung.Madanhgia);
            ViewData["Maquyen"] = new SelectList(_context.Vaitronguoidungs, "Maquyen", "Maquyen", nguoidung.Maquyen);
            return View(nguoidung);
        }

        // GET: Admin/Nguoidung/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoidung = await _context.Nguoidungs
                .Include(n => n.MadanhgiaNavigation)
                .Include(n => n.MaquyenNavigation)
                .FirstOrDefaultAsync(m => m.Manguoidung == id);
            if (nguoidung == null)
            {
                return NotFound();
            }

            return View(nguoidung);
        }

        // POST: Admin/Nguoidung/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nguoidung = await _context.Nguoidungs.FindAsync(id);
            _context.Nguoidungs.Remove(nguoidung);
            await _context.SaveChangesAsync();
            _notyfService.Success("Xóa thành công");
            return RedirectToAction(nameof(Index));
        }

        private bool NguoidungExists(int id)
        {
            return _context.Nguoidungs.Any(e => e.Manguoidung == id);
        }
    }
}

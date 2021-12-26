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
    public class DonhangController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public DonhangController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }




        public async Task<IActionResult> ChangeStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewData["Trangthai"] = new SelectList(_context.Transactions, "Idtransaction", "Tinhtrang", donhang.Idtransaction);
           
            return View(donhang);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeStatus(int id, [Bind("Madonhang,Mavoucher,Magiaohang,Manguoidung,Ngaydat,Ngayship,Tongdon,Hoten,Sdt,Diachi,Gioitinh,Email,Ghichu,Sotheodoi,Vanchuyen,Tinhtrangthanhtoan,Ngaythanhtoan,Ngayhethan,Khongdangky,Homeflag,Idtransaction,Thanhpho,Quan")] Donhang donhang)
        {
            if (id != donhang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var order = await _context.Donhangs.Include(x => x.ManguoidungNavigation).FirstOrDefaultAsync(x => x.Madonhang == donhang.Madonhang);
                    if (order!=null)
                    {
                        order.Tinhtrangthanhtoan = donhang.Tinhtrangthanhtoan;
                        order.Idtransaction = donhang.Idtransaction;
                        if (order.Tinhtrangthanhtoan=="Đã thanh toán")
                        {
                            var chitietdonhang = _context.Ctdhs
                            .Include(x => x.MaspNavigation)
                            .Where(x => x.Madonhang == order.Madonhang)
                            .OrderByDescending(x => x.Ngaytao)
                            .ToList();
                            foreach (var item in chitietdonhang)
                            {
                                Sanpham sanpham = _context.Sanphams.FirstOrDefault(x => x.Masp == item.Masp);
                                sanpham.Soluong = sanpham.Soluong - item.Soluong;
                                
                                _context.Update(sanpham);
                                _context.SaveChanges();
                            }
                           
                        }

                    }
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật trạng thái thành công");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.Madonhang))
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
            ViewData["Trangthai"] = new SelectList(_context.Transactions, "Idtransaction", "Idtransaction", donhang.Idtransaction);
          
            return View(donhang);
        }


        // GET: Admin/Donhang
        public async Task<IActionResult> Index()
        {
            var linhkienchinhthucContext = _context.Donhangs.Include(d => d.IdtransactionNavigation).Include(d => d.MagiaohangNavigation).Include(d => d.ManguoidungNavigation).Include(d => d.MavoucherNavigation);
            return View(await linhkienchinhthucContext.ToListAsync());
        }

        // GET: Admin/Donhang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .Include(d => d.IdtransactionNavigation)
                .Include(d => d.MagiaohangNavigation)
                .Include(d => d.ManguoidungNavigation)
                .Include(d => d.MavoucherNavigation)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (donhang == null)
            {
                return NotFound();
            }

            var chitietdonhang = _context.Ctdhs
                .Include(x=> x.MaspNavigation)
                .Where(x => x.Madonhang == donhang.Madonhang)
                .OrderByDescending(x => x.Ngaytao)
                .ToList();
            ViewBag.chitietdonhang = chitietdonhang;
            return View(donhang);
        }

        // GET: Admin/Donhang/Create
        public IActionResult Create()
        {
            ViewData["Idtransaction"] = new SelectList(_context.Transactions, "Idtransaction", "Idtransaction");
            ViewData["Magiaohang"] = new SelectList(_context.Giaohangs, "Magiaohang", "Magiaohang");
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung");
            ViewData["Mavoucher"] = new SelectList(_context.Vouchers, "Mavoucher", "Mavoucher");
            return View();
        }

        // POST: Admin/Donhang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madonhang,Mavoucher,Magiaohang,Manguoidung,Ngaydat,Ngayship,Tongdon,Hoten,Sdt,Diachi,Gioitinh,Email,Ghichu,Sotheodoi,Vanchuyen,Tinhtrangthanhtoan,Ngaythanhtoan,Ngayhethan,Khongdangky,Homeflag,Idtransaction,Thanhpho,Quan")] Donhang donhang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donhang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idtransaction"] = new SelectList(_context.Transactions, "Idtransaction", "Idtransaction", donhang.Idtransaction);
            ViewData["Magiaohang"] = new SelectList(_context.Giaohangs, "Magiaohang", "Magiaohang", donhang.Magiaohang);
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", donhang.Manguoidung);
            ViewData["Mavoucher"] = new SelectList(_context.Vouchers, "Mavoucher", "Mavoucher", donhang.Mavoucher);
            return View(donhang);
        }

        // GET: Admin/Donhang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs.FindAsync(id);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewData["Idtransaction"] = new SelectList(_context.Transactions, "Idtransaction", "Idtransaction", donhang.Idtransaction);
            ViewData["Magiaohang"] = new SelectList(_context.Giaohangs, "Magiaohang", "Magiaohang", donhang.Magiaohang);
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", donhang.Manguoidung);
            ViewData["Mavoucher"] = new SelectList(_context.Vouchers, "Mavoucher", "Mavoucher", donhang.Mavoucher);
            return View(donhang);
        }

        // POST: Admin/Donhang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Madonhang,Mavoucher,Magiaohang,Manguoidung,Ngaydat,Ngayship,Tongdon,Hoten,Sdt,Diachi,Gioitinh,Email,Ghichu,Sotheodoi,Vanchuyen,Tinhtrangthanhtoan,Ngaythanhtoan,Ngayhethan,Khongdangky,Homeflag,Idtransaction,Thanhpho,Quan")] Donhang donhang)
        {
            if (id != donhang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donhang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonhangExists(donhang.Madonhang))
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
            ViewData["Idtransaction"] = new SelectList(_context.Transactions, "Idtransaction", "Idtransaction", donhang.Idtransaction);
            ViewData["Magiaohang"] = new SelectList(_context.Giaohangs, "Magiaohang", "Magiaohang", donhang.Magiaohang);
            ViewData["Manguoidung"] = new SelectList(_context.Nguoidungs, "Manguoidung", "Manguoidung", donhang.Manguoidung);
            ViewData["Mavoucher"] = new SelectList(_context.Vouchers, "Mavoucher", "Mavoucher", donhang.Mavoucher);
            return View(donhang);
        }

        // GET: Admin/Donhang/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhang = await _context.Donhangs
                .Include(d => d.IdtransactionNavigation)
                .Include(d => d.MagiaohangNavigation)
                .Include(d => d.ManguoidungNavigation)
                .Include(d => d.MavoucherNavigation)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (donhang == null)
            {
                return NotFound();
            }

            return View(donhang);
        }

        // POST: Admin/Donhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donhang = await _context.Donhangs.FindAsync(id);
            _context.Donhangs.Remove(donhang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonhangExists(int id)
        {
            return _context.Donhangs.Any(e => e.Madonhang == id);
        }
    }
}

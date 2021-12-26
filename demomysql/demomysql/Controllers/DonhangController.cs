using AspNetCoreHero.ToastNotification.Abstractions;
using demomysql.Extension;
using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Controllers
{
    public class DonhangController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public DonhangController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult  Details(int id)
        {
           
            var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
            var khachhang = _context.Nguoidungs.Find(Convert.ToInt32(taikhoanid.Manguoidung));
            if (khachhang==null)
            {
                return NotFound();
            }

            var donhang =  _context.Donhangs
                .Include(x => x.IdtransactionNavigation)
                .Include(x=> x.MavoucherNavigation)
                .SingleOrDefault(s => s.Madonhang == id && taikhoanid.Manguoidung == s.Manguoidung);
            if (donhang == null)
            {
                return NotFound();
            }
            ViewBag.donghang = donhang;
            var chitietdonhang = _context.Ctdhs.Include(x => x.MaspNavigation).Where(x => x.Madonhang == id).ToList();
            return  PartialView("Details",chitietdonhang);
        }
    }
}

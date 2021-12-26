using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public HomeController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
       

        public int donhangtrongngay()
        {
            var donhang =_context.Donhangs.Count(x=> x.Ngaydat.Value.Date==DateTime.Today.Date);
            return donhang;
        }
        public int soluongkhachdk()
        {
            var slkhach = _context.Nguoidungs.Count(x => x.Maquyen == 3);
            return slkhach;
        }

        public int contacttrongngay()
        {
            var slcontact = _context.Contacts.Count(x => x.Ngaygui.Value.Date == DateTime.Today.Date);
            return slcontact;
        }

        public double tientrongthag(int? thang)
        {
            
            var donhang = _context.Donhangs.ToList().Where(x => Convert.ToDateTime(x.Ngaydat).Month ==thang && x.Tinhtrangthanhtoan.Equals("Đã thanh toán")).ToList();
            double tongtien = 0;
            foreach (var item in donhang)
            {
                tongtien += (double)item.Tongdon;
            }

            return tongtien;
        }

        

       
        public ActionResult Index(int?thang)
        {
            var tensp = _context.Sanphams.Select(x=> x.Tensp).ToList();
            var slsanpham = _context.Sanphams.Select(x => x.Soluong).ToList();
            if (thang==null)
            {
               thang=DateTime.Now.Month;
            }
            

            ViewBag.tensp = tensp;
            ViewBag.slsanpham = slsanpham;
            ViewBag.slkhach = soluongkhachdk();
            ViewBag.tongtien = tientrongthag(thang);
            ViewBag.donhang = donhangtrongngay();
            ViewBag.contact = contacttrongngay();

            return View(thang);
        }





    }
}

using AspNetCoreHero.ToastNotification.Abstractions;
using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Controllers
{
    public class HomeController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public HomeController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public IActionResult Index()
        {
            var lssanphamgiamgia = _context.Sanphams.Where(x=>  x.Madm == 7 && x.Giakm >=0.2)                  
                  .OrderByDescending(x => x.Giakm)
                  .ToList();
            ViewBag.spgiamgia = lssanphamgiamgia;

            var lsmanhinh = _context.Sanphams.Where(x => x.Madm == 8&& x.Banchay==true )
                 .OrderByDescending(x => x.Ngaydang)
                 .ToList();
            ViewBag.spmanhinh = lsmanhinh;

            var giamnhieu = _context.Sanphams.Where(x => x.Giakm >= 0.1 && x.Banchay == true).Take(8)
                .OrderByDescending(x => x.Giakm)
                .ToList();
            ViewBag.giamnhieu = giamnhieu;
            return View();
        }

        public IActionResult Contact()
        {         

            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact lienhe)
        {
            if (ModelState.IsValid)
            {
                lienhe.Tinhtrangdon = "đã nhận";
                lienhe.Ngaygui = DateTime.Now;
                _context.Add(lienhe);
                _context.SaveChanges();
                _notyfService.Success("Gửi thành công");
                return View();
            }
            _notyfService.Error("Gửi thất bại");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

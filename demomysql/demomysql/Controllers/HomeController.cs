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
        private readonly linhkienchinhthucContext _context;

        public HomeController(linhkienchinhthucContext context)
        {
            _context = context;
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
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}

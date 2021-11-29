using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Controllers
{
    public class BlogController : Controller
    {
        private readonly linhkienchinhthucContext _context;

        public BlogController(linhkienchinhthucContext context)
        {
            _context = context;
        }
        public IActionResult Index(int ? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 4;
            var danhsachtintuc = _context.Tintucs.AsNoTracking().OrderByDescending(x => x.Matintuc);
            PagedList<Tintuc> models = new PagedList<Tintuc>(danhsachtintuc, pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        public IActionResult Details(int id)
        {
            var tintuc = _context.Tintucs.Find(id);
            if (tintuc == null)
            {
                return RedirectToAction("Index");
            }
            var lsBaivietlienquan = _context.Tintucs.Where(x => x.Matintuc != id && x.Hot==1)
                .Take(3)
                .OrderByDescending(x => x.Ngaydang)
                .ToList();

            ViewBag.Baivietlienquan = lsBaivietlienquan;
            return View(tintuc);
        }
    }
}

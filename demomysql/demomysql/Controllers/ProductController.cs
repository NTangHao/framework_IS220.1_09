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
    public class ProductController : Controller
    {
        private readonly linhkienchinhthucContext _context;

        public ProductController(linhkienchinhthucContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            try
            {
                var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var pageSize = 9;
                var danhsachsanpham = _context.Sanphams.AsNoTracking().OrderByDescending(x => x.Ngaydang);
                PagedList<Sanpham> models = new PagedList<Sanpham>(danhsachsanpham, pageNumber, pageSize);
                ViewBag.CurrentPage = pageNumber;

                return View(models);
            }
            catch 
            {

                return RedirectToAction("Index", "Home");
            }
            
        }
        public IActionResult ListDanhmucSP(string tendm, int page =1)// danh sach sản phẩm theo danh mục
        {
            try
            {
                var pageSize = 2;
                var danhmuc = _context.Danhmucs.SingleOrDefault(x => x.Tendm == tendm);

                //var pageNumber = page == null || page <= 0 ? 1 : page.Value;
                var sanphamdanhmuc = _context.Sanphams.AsNoTracking().Where(x => x.Madm ==danhmuc.Madm);
                PagedList<Sanpham> models = new PagedList<Sanpham>(sanphamdanhmuc, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentDm = danhmuc;
                return View(models);

               
               

            }
            catch 
            {

                return RedirectToAction("Index", "Home");
            }

            
        }

        public IActionResult Details(int id)
        {
               var sanpham = _context.Sanphams.FirstOrDefault(x => x.Masp == id);
            var thuonghieu = _context.Thuonghieus.FirstOrDefault(x => x.Mathuonghieu == sanpham.Mathuonghieu);
            var danhmuc = _context.Danhmucs.FirstOrDefault(x => x.Madm == sanpham.Madm);
            var lshinhanh = _context.Anhthems.Where(x => x.Masp == id).ToList();
            var lsSPlienquan = _context.Sanphams.Where(x => x.Masp != id && x.Banchay == true && x.Madm == sanpham.Madm)
                .Take(4) 
                .OrderByDescending(x => x.Ngaydang)
                .ToList();

            ViewBag.tenthuonghieu = thuonghieu;
            ViewBag.tendanhmuc = danhmuc;
            ViewBag.hinhanhthem = lshinhanh;
            ViewBag.sanphamlienquan = lsSPlienquan;

            if (sanpham == null)
                {
                    return RedirectToAction("Index");
                }
                return View(sanpham);
           

            
        }

    }
}

using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace demomysql.Controllers
{
    public class SearchController:Controller
    {
        private readonly linhkienchinhthucContext _context;

        public SearchController(linhkienchinhthucContext context)
        {
            _context = context;
        }

       public IActionResult Index(string keyword, int? page)
        {
            
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var danhsachtimkiem = _context.Sanphams
                .Where(x => x.Tensp
                .Contains(keyword))
                .OrderByDescending(x => x.Tensp)
                .Take(10);
                
            PagedList<Sanpham> lssanpham = new PagedList<Sanpham>(danhsachtimkiem, pageNumber, pageSize);
           
          
                return View(lssanpham);
            
        }
       
        [HttpPost]
        public JsonResult FindProduct(string keyword)
        {
            List<Sanpham> lssanpham = new List<Sanpham>();
         
            lssanpham = _context.Sanphams
                .Where(x => x.Tensp
                .Contains(keyword))
                .OrderByDescending(x => x.Tensp)
                .Take(10)
                .ToList();
            if (lssanpham == null)
            {
              
                return Json(lssanpham);

            }
            else
            {
             
                return Json(lssanpham);
            }


        }

    }
}

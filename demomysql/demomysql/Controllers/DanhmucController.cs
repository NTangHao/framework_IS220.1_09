using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
using Microsoft.EntityFrameworkCore;

namespace demomysql.Controllers
{
    public class DanhmucController : Controller
    {
       
        
        public ActionResult Danhsachdanhmuc()
        {           
            //// var query = from table in db.Danhmucs   select table;                   

            //List<Danhmuc> query = db.Danhmucs.ToList();
            //return View(query);

            linhkienchinhthucContext db = new linhkienchinhthucContext();
            var query = from table in db.Danhmucs select table;
            return View(query);

        }
    }
}

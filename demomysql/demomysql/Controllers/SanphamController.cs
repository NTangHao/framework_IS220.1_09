using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Controllers
{
    public class SanphamController : Controller
    {
        public ActionResult Danhsachsanpham(int id)
        {
            linhkienchinhthucContext db = new linhkienchinhthucContext();
            var query = from table in db.Sanphams  where table.Madm== id select table;

            return View(query);
        }
       public ActionResult Chitietsanpham(int id)
        {
            linhkienchinhthucContext db = new linhkienchinhthucContext();
            var ketqua = db.Sanphams.Find(id);
            return View(ketqua);
        }
       
    }
}

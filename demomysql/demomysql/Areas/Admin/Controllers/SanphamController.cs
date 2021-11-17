using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
namespace demomysql.Areas.Admin.Controllers
{
    public class SanphamController : Controller
    {
        private readonly linhkienchinhthucContext _context;

        public SanphamController(linhkienchinhthucContext context)
        {
            _context = context;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            var query = from table in _context.Sanphams select table;
            return View(query);
        }
    }
}

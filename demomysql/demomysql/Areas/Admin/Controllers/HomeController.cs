using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Models;
namespace demomysql.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public ActionResult Index()
        {
            return View();
        }
      



    }
}

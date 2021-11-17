using demomysql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        [Area("Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(string username, string password)
        {

          
            linhkienchinhthucContext db = new linhkienchinhthucContext();
            //var query = db.Nguoidungs.FirstOrDefault(u => u.Username == username && u.Password == password);
            var data = db.Nguoidungs.Where(s => s.Username.Equals(username) && s.Password.Equals(password)).ToList();
            if (data.Count() > 0)
            {
                TempData["userlogin"] = username;
                //HttpContext.Session.SetString("username", username);
                return RedirectToAction("Index", "Home");
            }

           

            else 
            {
                TempData["result"] = "Đăng nhập không thành công";
                return RedirectToAction("Index", "Login");
            }

            
        }
    }
}

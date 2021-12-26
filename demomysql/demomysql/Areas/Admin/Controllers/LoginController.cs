using demomysql.Extension;
using demomysql.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
       
        [HttpGet]
        public IActionResult Index()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }
       
        [HttpPost]
        public IActionResult Index(string username, string password)
        {

          
            linhkienchinhthucContext db = new linhkienchinhthucContext();
            
            var data = db.Nguoidungs.SingleOrDefault(s => s.Username.Equals(username) && s.Password.Equals(password) &&s.Maquyen.Equals(1));
            if (data!=null)
            {
                //TempData["userlogin"] = username;
                //HttpContext.Session.SetString("userlogin", username);
                HttpContext.Session.SetString("SessionAdmin", JsonConvert.SerializeObject(data));
               // HttpContext.Session.Set("SessionAdmin", data);
                return RedirectToAction("Index", "Home");
            }

           

            else 
            {
                TempData["result"] = "Đăng nhập không thành công";
                return RedirectToAction("Index", "Login");
            }

            
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("SessionAdmin");
            return RedirectToAction("Index");
        }
    }
}

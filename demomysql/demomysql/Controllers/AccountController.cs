using demomysql.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.Helper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace demomysql.Controllers
{
    public class AccountController : Controller
    {
        private readonly linhkienchinhthucContext _context;

        public AccountController(linhkienchinhthucContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Maquyen,Username,Password,Hoten,Ngaysinh,Email,,Ngaytao,Vaitro,Trangthai,Dienthoai")] Nguoidung nguoidung)
        {
            

            if (ModelState.IsValid)
            {
                var check = _context.Nguoidungs.FirstOrDefault(x => x.Email == nguoidung.Email);
                if (check==null)
                {
                    nguoidung.Maquyen = 3;
                    nguoidung.Vaitro = "khách hàng";
                    nguoidung.Trangthai = true;
                    nguoidung.Ngaytao = DateTime.Now;
                    _context.Add(nguoidung);
                    await _context.SaveChangesAsync();
                   // HttpContext.Session.SetString("Manguoidung", nguoidung.Manguoidung.ToString());
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }

            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            if (HttpContext.Session.GetString("Sessionkhachhang") !=null)
            {

                return RedirectToAction("Dashboard", "Account");
            }
            return View();
           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(string username, string password)
        {
            //var data = _context.Nguoidungs.Where(s => s.Username.Equals(username) && s.Password.Equals(password) &&s.Maquyen==3).ToList();

            if (ModelState.IsValid)
            {
                var data = _context.Nguoidungs.AsNoTracking().SingleOrDefault(s => s.Username.Equals(username) && s.Password.Equals(password) && s.Maquyen == 3);
                if (data != null)
                {
                    HttpContext.Session.SetString("Sessionkhachhang", JsonConvert.SerializeObject(data));
                    //ViewBag.IsAuthenticated = HttpContext.Session.GetString("Sessionkhachhang");
                    //var taikhoan = JsonConvert.DeserializeObject<List<Nguoidung>>(HttpContext.Session.GetString("Sessionkhachhang"));
                    var taikhoan = JsonConvert.DeserializeObject<Nguoidung>(HttpContext.Session.GetString("Sessionkhachhang"));
                    ViewBag.IsAuthenticated = taikhoan;
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    TempData["result"] = "Đăng nhập không thành công";
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }



       

        public IActionResult Dashboard()
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetString("Sessionkhachhang") != null)
                {
                    var taikhoan = JsonConvert.DeserializeObject<Nguoidung>(HttpContext.Session.GetString("Sessionkhachhang"));
                   
                    var lsdonhang = _context.Donhangs
                        .Include(x => x.IdtransactionNavigation)
                        .AsNoTracking()
                        .Where(x => x.Manguoidung == taikhoan.Manguoidung)
                        .OrderByDescending(x => x.Ngaydat).ToList();
                    ViewBag.dsdonhang = lsdonhang;
                    return View(taikhoan);

                }
            }
           
            return RedirectToAction("Login", "Account");
        }


        //public IActionResult UpdateAccount()
        //{
        //      if (HttpContext.Session.GetString("Sessionkhachhang") != null)
        //        {
        //            var taikhoan = JsonConvert.DeserializeObject<Nguoidung>(HttpContext.Session.GetString("Sessionkhachhang"));
        //            return View(taikhoan);
        //        }

        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAccount([Bind("Username,Password,Hoten,Ngaysinh,Email,Dienthoai")] Nguoidung nguoidung)
        {
            if (ModelState.IsValid)
            {
                var taikhoanid = JsonConvert.DeserializeObject<Nguoidung>(HttpContext.Session.GetString("Sessionkhachhang"));


                //nguoidung = taikhoanid;
                nguoidung.Maquyen = taikhoanid.Maquyen;
                nguoidung.Manguoidung = taikhoanid.Manguoidung;
                //var capnhat = _context.Nguoidungs.SingleOrDefault(x => x.Manguoidung == taikhoanid.Manguoidung);
                //nguoidung = capnhat;
                _context.Update(nguoidung);
                _context.SaveChanges();
                ViewBag.capnhat = nguoidung;
                return RedirectToAction("Dashboard");

            }

            return View(nguoidung);


        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Sessionkhachhang");
            return RedirectToAction("Login","Account");
        }

    }
}

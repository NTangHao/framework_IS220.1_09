using AspNetCoreHero.ToastNotification.Abstractions;
using demomysql.Extension;
using demomysql.Helper;
using demomysql.Models;
using demomysql.ModelViews;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace demomysql.Controllers
{
    public class AccountsController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;

        public AccountsController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
       

        public IActionResult ValidatePhone(string Phone)
        {
            var khachhang = _context.Nguoidungs.SingleOrDefault(x => x.Dienthoai.ToLower() == Phone.ToLower());
            if (khachhang != null)
            {
                return Json(data: "Số điện thoại :" + Phone + "đã được sử dụng");
            }
            return Json(data: true);
        }

        public IActionResult ValidateEmail(string Email)
        {
            var khachhang = _context.Nguoidungs.SingleOrDefault(x => x.Email.ToLower() == Email.ToLower());
            if (khachhang != null)
            {
                return Json(data: "Email :" + Email + "đã được sử dụng");
            }
            return Json(data: true);
        }
        public IActionResult Register()
        {
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterVM taikhoan)
        {

            if (ModelState.IsValid)
            {

                string RandomKey = Utilities.GetRandomKey();

                Nguoidung khachhang = new Nguoidung
                {
                    Hoten = taikhoan.FullName,
                    Dienthoai = taikhoan.Phone.Trim().ToLower(),
                    Email = taikhoan.Email,
                    Password = (taikhoan.Password).ToMD5(),
                    Ngaytao = DateTime.Now,
                    Maquyen = 3,
                    Trangthai = true,

                };

                var check = _context.Nguoidungs.FirstOrDefault(x => x.Email == taikhoan.Email);
                if (check == null)
                {
                    _context.Add(khachhang);
                    await _context.SaveChangesAsync();

                    HttpContext.Session.SetString("CustomerID", khachhang.Manguoidung.ToString());
                    var taikhoanId = HttpContext.Session.GetString("CustomerID");

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["result"] = "Email đã được sử dụng";
                    return RedirectToAction("Register", "Accounts");
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
            if (HttpContext.Session.GetString("Sessionkhachhang") != null)
            {

                return RedirectToAction("Dashboard", "Accounts");
            }
            return View();

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginViewModel customer)
        {
            //var data = _context.Nguoidungs.Where(s => s.Username.Equals(username) && s.Password.Equals(password) &&s.Maquyen==3).ToList();
            if (ModelState.IsValid)
            {
                var f_password = HashMD5.ToMD5(customer.Password);

                var data = _context.Nguoidungs.AsNoTracking().SingleOrDefault(s => s.Email.Equals(customer.UserName) && s.Password.Equals(f_password) && s.Maquyen == 3);
                if (data != null)
                {
                   
                    HttpContext.Session.Set("Sessionkhachhang", data);
                   
                    return RedirectToAction("Login", "Accounts");
                }
                else
                {
                    TempData["result"] = "Đăng nhập không thành công";
                    return RedirectToAction("Login", "Accounts");
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
                   // var taikhoan = JsonConvert.DeserializeObject<Nguoidung>(HttpContext.Session.GetString("Sessionkhachhang"));
                    var taikhoan =  HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
                    var lsdonhang = _context.Donhangs
                        .Include(x => x.IdtransactionNavigation)
                        .AsNoTracking()
                        .Where(x => x.Manguoidung == taikhoan.Manguoidung)
                        .OrderByDescending(x => x.Ngaydat).ToList();
                    ViewBag.dsdonhang = lsdonhang;
                    return View(taikhoan);

                }
            }

            return RedirectToAction("Login", "Accounts");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Sessionkhachhang");
            return RedirectToAction("Login", "Accounts");
        }

        

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
            var taikhoan = _context.Nguoidungs.Find(Convert.ToInt32(taikhoanid.Manguoidung));
            if (ModelState.IsValid)
            {
                var passnow = (model.PasswordNow).ToMD5();
                if (passnow == taikhoan.Password)
                {
                    string newpass = (model.Password).ToMD5();
                    taikhoan.Password = newpass;
                    _context.Update(taikhoan);
                    _context.SaveChanges();
                    _notyfService.Success("Đổi mật khẩu thành công");
                    return RedirectToAction("Dashboard", "Accounts");
                }

                
            }
            _notyfService.Success("Đổi mật khẩu không thành công");
            return RedirectToAction("Dashboard", "Accounts");
        }

        [HttpPost]
        public IActionResult UpdateAccount(UpdateAccountMV accountMV)
        {
            var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
            var taikhoan = _context.Nguoidungs.Find(Convert.ToInt32(taikhoanid.Manguoidung));
            if (ModelState.IsValid)
            {
                taikhoan.Hoten = accountMV.Hoten;
                taikhoan.Dienthoai = accountMV.dienthoai;
                taikhoan.Ngaysua = DateTime.Now;
                _context.Update(taikhoan);
                _context.SaveChanges();
                _notyfService.Success("Đổi thông tin thành công");
                return RedirectToAction("Dashboard");
            }
            _notyfService.Error("Đổi thông tin thất bại");
            return RedirectToAction("Dashboard");
        }
    }
}

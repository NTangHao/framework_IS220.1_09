using AspNetCoreHero.ToastNotification.Abstractions;
using demomysql.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demomysql.ModelViews;
using demomysql.Extension;
namespace demomysql.Controllers
{
   
    public class ShoppingcartController : Controller
    {

        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;
        public ShoppingcartController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        public List<CartItem> Giohang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("Giohang");
                if (gh==null)
                {
                    gh = new List<CartItem>();
                }

              
                return gh;
                
            }
        }

        public IActionResult Index()
        {
            return View(Giohang);
        }

       public IActionResult AddToCart(int id,int soluong, string type="normal")
        {
            List<CartItem> myCart = Giohang;
           var item = myCart.SingleOrDefault(x => x.masp == id);
            if (item == null)
            {
                var sanpham = _context.Sanphams.SingleOrDefault(x => x.Masp == id);
                if (sanpham.Soluong < soluong)
                {
                    _notyfService.Error("Sản phẩm không đủ");
                    return RedirectToAction("Index");
                }
               
                item = new CartItem
                {
                    masp = id,
                    tensp = sanpham.Tensp,
                    dongia = (sanpham.Dongia - sanpham.Dongia*sanpham.Giakm).Value,
                    soluong = soluong,
                    hinhanh= sanpham.Hinhanh

                };
                myCart.Add(item); 
            }
            else
            {
                item.soluong+= soluong;
            }
            HttpContext.Session.Set("Giohang", myCart);// cap nhat lai session gio hang moi
           // HttpContext.Session.Set<List<CartItem>>("Giohang", Giohang);
            if (type== "ajax")
            {
               
                return Json(new
                {
                    soluong = Giohang.Sum(x=> x.soluong),
                    tongtien = Giohang.Sum(x=> x.thanhtien)
                });
            }
           
            
            _notyfService.Success("Thêm giỏ hàng thành công");
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem (int id)
        {

           var myCart = Giohang;
            var item = myCart.SingleOrDefault(x => x.masp == id);
            var sanpham = _context.Sanphams.SingleOrDefault(x => x.Masp == id);
          
            myCart.Remove(item);

           HttpContext.Session.Set("Giohang", myCart);// cap nhat lai session gio hang moi

            return RedirectToAction("Index");

        }
        
        public IActionResult UpdateCart(int id, int? soluong)
        {
            List<CartItem> myCart = Giohang;
            CartItem item = myCart.SingleOrDefault(x=> x.masp== id);
           
      
            
           
            if (item != null &&soluong.HasValue)
            {
                item.soluong = soluong.Value;
            }

            HttpContext.Session.Set("Giohang", myCart);// cap nhat lai session gio hang moi
                                                       // HttpContext.Session.Set<List<CartItem>>("Giohang", Giohang);
            return RedirectToAction("Index");
        }

        public IActionResult Voucher(string ma)
        {
            List<CartItem> myCart = Giohang;
          

            var check = _context.Vouchers.SingleOrDefault(s => s.Tenma.Equals(ma));
            if (check!=null)
            {

            }



            HttpContext.Session.Set("Giohang", myCart);// cap nhat lai session gio hang moi
                                                       // HttpContext.Session.Set<List<CartItem>>("Giohang", Giohang);
            return RedirectToAction("Index");
        }

    }
}

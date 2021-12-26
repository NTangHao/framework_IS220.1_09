using AspNetCoreHero.ToastNotification.Abstractions;
using demomysql.Extension;
using demomysql.Models;
using demomysql.ModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.XlsIO;
using System.IO;
using Syncfusion.Drawing;
using System.Globalization;

namespace demomysql.Controllers
{
    public class CheckoutController : Controller
    {
        public INotyfService _notyfService { get; }
        private readonly linhkienchinhthucContext _context;
        public static  Voucher ma ;
        public static Donhang donhangmoi = new Donhang();
        public CheckoutController(linhkienchinhthucContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        public List<CartItem> Giohang
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("Giohang");
                if (gh == null)
                {
                    gh = new List<CartItem>();
                }


                return gh;

            }
        }
        [HttpGet]
        public IActionResult Index()
        {
            MuaHangVM model = new MuaHangVM();
            var myCart = Giohang;
            var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
           
           

            if (taikhoanid != null)
            {
                var taikhoan = _context.Nguoidungs.Find(Convert.ToInt32(taikhoanid.Manguoidung));
                model.CustomerId = taikhoan.Manguoidung;
                model.FullName = taikhoan.Hoten;
                model.Email = taikhoan.Email;
                model.Phone = taikhoan.Dienthoai;
            }

            ViewBag.giohang = myCart;

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(MuaHangVM muaHang)
        {
            if (TempData["ketqua"] != null)
            {
                ViewBag.error = TempData["ketqua"];
            }
            MuaHangVM model = new MuaHangVM();
            var myCart = Giohang;
            var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
            if (taikhoanid != null)
            {
                var taikhoan = _context.Nguoidungs.Find(Convert.ToInt32(taikhoanid.Manguoidung));
                model.CustomerId = taikhoan.Manguoidung;
                model.FullName = taikhoan.Hoten;
                model.Email = taikhoan.Email;
                model.Phone = taikhoan.Dienthoai;
            }
            if (taikhoanid==null)
            {
                if (ModelState.IsValid)
                {
                    var total = myCart.Sum(x => x.thanhtien);
                    Donhang donhang = new Donhang();                  
                    donhang.Hoten = muaHang.FullName;
                    donhang.Ngaydat = DateTime.Now;
                    donhang.Sdt = muaHang.Phone;
                    donhang.Diachi = muaHang.Address;
                    donhang.Thanhpho = muaHang.TinhThanh;
                    donhang.Quan = muaHang.QuanHuyen;
                    donhang.Idtransaction = 1;
                    donhang.Tinhtrangthanhtoan = "Chưa thanh toán";
                    donhang.Email = muaHang.Email;
                    donhang.Ghichu = muaHang.Note;
                    donhang.Khongdangky = 1;
                 
                    if (ma != null)
                    {
                        donhang.Tongdon = total - total * (float)((ma.Tyle / 100));
                        donhang.Mavoucher = ma.Mavoucher;
                    }
                    else
                    {
                        donhang.Tongdon = total;

                    }
                   
                    _context.Add(donhang);
                    _context.SaveChanges();
                    donhangmoi = donhang;

                    foreach (var item in myCart)
                    {
                        Ctdh ctdh = new Ctdh();
                        ctdh.Madonhang = donhang.Madonhang;
                        ctdh.Masp = item.masp;
                        ctdh.Soluong = item.soluong;
                        ctdh.Dongia = item.dongia;
                        ctdh.Tongtien = donhang.Tongdon;
                        ctdh.Ngaytao = DateTime.Now;
                        _context.Add(ctdh);
                    }
                    _context.SaveChanges();

                    _notyfService.Success("ĐẶT HÀNG THÀNH CÔNG");
                    HttpContext.Session.Remove("Giohang");
                    return RedirectToAction("Sucess");

                }
            }

            if (ModelState.IsValid)
            {
                
                Donhang donhang = new Donhang();
                var total = myCart.Sum(x => x.thanhtien);
                donhang.Manguoidung = muaHang.CustomerId;
                donhang.Hoten = muaHang.FullName;
                donhang.Ngaydat = DateTime.Now;
                donhang.Sdt = muaHang.Phone;
                donhang.Diachi = muaHang.Address;
                donhang.Thanhpho = muaHang.TinhThanh;
                donhang.Quan = muaHang.QuanHuyen;
                donhang.Idtransaction = 1;
                donhang.Tinhtrangthanhtoan = "Chưa thanh toán";
                donhang.Ghichu = muaHang.Note;
                if (ma!=null)
                {
                    donhang.Tongdon = total - total * (float)((ma.Tyle / 100));
                    donhang.Mavoucher = ma.Mavoucher;
                }
                else { 
                    donhang.Tongdon = total;

                }
                
                
                _context.Add(donhang);
                _context.SaveChanges();
                donhangmoi = donhang;
                foreach (var item in myCart)
                {
                    Ctdh ctdh = new Ctdh();
                    ctdh.Madonhang = donhang.Madonhang;
                    ctdh.Masp = item.masp;
                    ctdh.Soluong = item.soluong;
                    ctdh.Dongia = item.dongia;
                    ctdh.Tongtien = donhang.Tongdon;
                    ctdh.Ngaytao = DateTime.Now;
                    _context.Add(ctdh);
                }
                _context.SaveChanges();

                _notyfService.Success("ĐẶT HÀNG THÀNH CÔNG");
                HttpContext.Session.Remove("Giohang");
                return RedirectToAction("Sucess");

            }
            ViewBag.giohang = myCart;
            _notyfService.Success("ĐẶT KHÔNG THÀNH CÔNG");
            return View(model);
        }

        public IActionResult Sucess()
        {
          
            return View(donhangmoi);
        }
        [HttpPost]
        public JsonResult Voucher(string NameVoucher)
        {
            var voucher = _context.Vouchers.SingleOrDefault(x => x.Tenma == NameVoucher && x.Ngaybd<=DateTime.Now && x.Ngaykt>=DateTime.Now);
            if (voucher==null)
            {
                TempData["ketqua"] = "Không tìm thấy mã giảm giá";
                
            }         
            ma = voucher;
            return Json(voucher);
        }

        public IActionResult CreateDocument()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                var myCart = Giohang;
                var taikhoanid = HttpContext.Session.Get<Nguoidung>("Sessionkhachhang");
                if (taikhoanid==null)
                {
                    taikhoanid = new Nguoidung();
                }

                IApplication application = excelEngine.Excel;

                application.DefaultVersion = ExcelVersion.Excel2016;
                //Create a workbook
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];

                //Adding a picture
                FileStream imageStream = new FileStream(@"F:\HTTT tren framework\logopage.png", FileMode.Open, FileAccess.Read);
                IPictureShape shape = worksheet.Pictures.AddPicture(1, 1, imageStream,70,70);

                //Disable gridlines in the worksheet
                worksheet.IsGridLinesVisible = false;

                //Enter values to the cells from A3 to A5
                worksheet.Range["A3"].Text = "203 NGUYỄN THƯỢNG HIỀN, P6, QUẬN BÌNH THẠNH TPHCM";
                worksheet.Range["A4"].Text = "ShopKraken@gmail.com";
                worksheet.Range["A5"].Text = "sdt: 0946700006";

                //Make the text bold
                worksheet.Range["A3:A5"].CellStyle.Font.Bold = true;

                ////////////


                //Merge cells
                worksheet.Range["D1:E1"].Merge();

                //Enter text to the cell D1 and apply formatting.
                worksheet.Range["D1"].Text = "KRAKEN";
                worksheet.Range["D1"].CellStyle.Font.Bold = true;
                worksheet.Range["D1"].CellStyle.Font.RGBColor = Color.FromArgb(42, 118, 189);
                worksheet.Range["D1"].CellStyle.Font.Size = 35;

                //Apply alignment in the cell D1
                worksheet.Range["D1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                worksheet.Range["D1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;

                //Enter values to the cells from D5 to E8
                worksheet.Range["D5"].Text = "ĐIỆN THOẠI";
                worksheet.Range["E5"].Text = "NGÀY ĐẶT";
                worksheet.Range["D6"].Text = taikhoanid.Dienthoai;
                worksheet.Range["E6"].Value = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                worksheet.Range["D7"].Text = "HỌ TÊN";
                worksheet.Range["E7"].Text = "EMAIL";
                worksheet.Range["D8"].Text = taikhoanid.Hoten;
                worksheet.Range["E8"].Text = taikhoanid.Email;

                //Apply RGB backcolor to the cells from D5 to E8
                worksheet.Range["D5:E5"].CellStyle.Color = Color.FromArgb(42, 118, 189);
                worksheet.Range["D7:E7"].CellStyle.Color = Color.FromArgb(42, 118, 189);

                //Apply known colors to the text in cells D5 to E8
                worksheet.Range["D5:E5"].CellStyle.Font.Color = ExcelKnownColors.White;
                worksheet.Range["D7:E7"].CellStyle.Font.Color = ExcelKnownColors.White;

                //Make the text as bold from D5 to E8
                worksheet.Range["D5:E8"].CellStyle.Font.Bold = true;

                //Apply alignment to the cells from D5 to E8
                worksheet.Range["D5:E8"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range["D5:E5"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                worksheet.Range["D7:E7"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
                worksheet.Range["D6:E6"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignTop;

                //Enter value and applying formatting in the cell A7
                worksheet.Range["A7"].Text = "ĐƠN HÀNG";
                worksheet.Range["A7"].CellStyle.Color = Color.FromArgb(42, 118, 189);
                worksheet.Range["A7"].CellStyle.Font.Bold = true;
                worksheet.Range["A7"].CellStyle.Font.Color = ExcelKnownColors.White;

                //Apply alignment
                worksheet.Range["A7"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
                worksheet.Range["A7"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;

               

                //worksheet.Range["A22:B22"].Merge();

                //Enter details of products and prices
                worksheet.Range["A15"].Text = "  SẢN PHẨM";
                worksheet.Range["B15"].Text = "SỐ LƯỢNG";
                worksheet.Range["C15"].Text = "ĐƠN GIÁ";
                worksheet.Range["D15"].Text = "THÀNH TIỀN";
                int rowix = 16;
                foreach (var item in myCart)
                {
                    worksheet.Range[rowix, 1].Value = item.tensp;
                    worksheet.Range[rowix, 2].Number = item.soluong;
                    worksheet.Range[rowix, 3].Number = item.dongia;
                    worksheet.Range[rowix, 4].Number = item.thanhtien;
                    rowix++;
                }
                worksheet.UsedRange.AutofitColumns();
             
                worksheet.Range["D23"].Text = "Tổng tiền";

                //Apply number format
                worksheet.Range["D16:E22"].NumberFormat = "#,##0";
                worksheet.Range["E23"].NumberFormat = "#,##0";

                //Apply incremental formula for column Amount by multiplying Qty and UnitPrice
              

                //Formula for Sum the total
                worksheet.Range["E23"].Number = myCart.Sum(x => x.thanhtien);

                //Apply borders
                worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].Color = ExcelKnownColors.Grey_25_percent;
                worksheet.Range["A16:E22"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Grey_25_percent;
                worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].LineStyle = ExcelLineStyle.Thin;
                worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeTop].Color = ExcelKnownColors.Black;
                worksheet.Range["A23:E23"].CellStyle.Borders[ExcelBordersIndex.EdgeBottom].Color = ExcelKnownColors.Black;

                //Apply font setting for cells with product details
                worksheet.Range["A3:E23"].CellStyle.Font.FontName = "Arial";
                worksheet.Range["A3:E23"].CellStyle.Font.Size = 10;
                worksheet.Range["A15:E15"].CellStyle.Font.Color = ExcelKnownColors.White;
                worksheet.Range["A15:E15"].CellStyle.Font.Bold = true;
                worksheet.Range["D23:E23"].CellStyle.Font.Bold = true;

                //Apply cell color
                worksheet.Range["A15:E15"].CellStyle.Color = Color.FromArgb(42, 118, 189);

                //Apply alignment to cells with product details
                worksheet.Range["A15"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignLeft;
                worksheet.Range["C15:C22"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                worksheet.Range["D15:E15"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

                //Apply row height and column width to look good
                worksheet.Range["A1"].ColumnWidth = 36;
                worksheet.Range["B1"].ColumnWidth = 11;
                worksheet.Range["C1"].ColumnWidth = 13;
                worksheet.Range["D1:E1"].ColumnWidth = 18;
                worksheet.Range["A1"].RowHeight = 47;
                worksheet.Range["A2"].RowHeight = 15;
                worksheet.Range["A3:A4"].RowHeight = 15;
                worksheet.Range["A5"].RowHeight = 18;
                worksheet.Range["A6"].RowHeight = 29;
                worksheet.Range["A7"].RowHeight = 18;
                worksheet.Range["A8"].RowHeight = 15;
                worksheet.Range["A9:A14"].RowHeight = 15;
                worksheet.Range["A15:A23"].RowHeight = 18;
               
                /////////
                //save excel workbook  in stream
                MemoryStream stream = new MemoryStream();

                workbook.SaveAs(stream);
                stream.Position=0;

                FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/excel");
                fileStreamResult.FileDownloadName = "Baogia.xlsx";
                return fileStreamResult;
            }
            
        }



    }
}

﻿using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Donhang
    {
        public Donhang()
        {
            Ctdhs = new HashSet<Ctdh>();
        }

        public int Madonhang { get; set; }
        public int? Mavoucher { get; set; }
        public int? Magiaohang { get; set; }
        public int? Manguoidung { get; set; }
        public DateTime? Ngaydat { get; set; }
        public DateTime? Ngayship { get; set; }
        public double? Tongdon { get; set; }
        public string Hoten { get; set; }
        public string Sdt { get; set; }
        public string Diachi { get; set; }
        public string Gioitinh { get; set; }
        public string Email { get; set; }
        public string Ghichu { get; set; }
        public string Sotheodoi { get; set; }
        public string Vanchuyen { get; set; }
        public string Tinhtrangthanhtoan { get; set; }
        public DateTime? Ngaythanhtoan { get; set; }
        public DateTime? Ngayhethan { get; set; }
        public string Transactionid { get; set; }

        public virtual Giaohang MagiaohangNavigation { get; set; }
        public virtual Nguoidung ManguoidungNavigation { get; set; }
        public virtual Voucher MavoucherNavigation { get; set; }
        public virtual ICollection<Ctdh> Ctdhs { get; set; }
    }
}

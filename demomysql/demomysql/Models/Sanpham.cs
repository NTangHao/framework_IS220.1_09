using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Ctdhs = new HashSet<Ctdh>();
            Hinhanhs = new HashSet<Hinhanh>();
        }

        public int Masp { get; set; }
        public int? Mathuonghieu { get; set; }
        public int? Madm { get; set; }
        public string Tensp { get; set; }
        public string Chitiet { get; set; }
        public double? Dongia { get; set; }
        public double? Giakm { get; set; }
        public int? Baohanh { get; set; }
        public double? Luotxem { get; set; }
        public DateTime? Ngaydang { get; set; }
        public int? Soluong { get; set; }
        public bool? Banchay { get; set; }
        public string Hinhanh { get; set; }
        public string Tinhtrangsp { get; set; }

        public virtual Danhmuc MadmNavigation { get; set; }
        public virtual Thuonghieu MathuonghieuNavigation { get; set; }
        public virtual ICollection<Ctdh> Ctdhs { get; set; }
        public virtual ICollection<Hinhanh> Hinhanhs { get; set; }
    }
}

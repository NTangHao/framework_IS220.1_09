using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Ctdh
    {
        public int Masp { get; set; }
        public int Madonhang { get; set; }
        public double? Dongia { get; set; }
        public int? Soluong { get; set; }

        public virtual Donhang MadonhangNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}

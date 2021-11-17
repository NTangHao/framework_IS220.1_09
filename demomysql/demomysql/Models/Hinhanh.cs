using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Hinhanh
    {
        public int Maanh { get; set; }
        public int Masp { get; set; }
        public string Linkanh { get; set; }

        public virtual Sanpham MaspNavigation { get; set; }
    }
}

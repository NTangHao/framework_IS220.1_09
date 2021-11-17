using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Mathuonghieu { get; set; }
        public string Tenthuonghieu { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Tintuc
    {
        public int Matintuc { get; set; }
        public int Manguoidung { get; set; }
        public string Tieude { get; set; }
        public string Motangan { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaydang { get; set; }
        public DateTime? Ngaysua { get; set; }
        public string Hinhanh { get; set; }
        public byte? Hot { get; set; }

        public virtual Nguoidung ManguoidungNavigation { get; set; }
    }
}

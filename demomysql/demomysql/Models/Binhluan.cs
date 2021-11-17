using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Binhluan
    {
        public int Mabinhluan { get; set; }
        public int Manguoidung { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaytao { get; set; }

        public virtual Nguoidung ManguoidungNavigation { get; set; }
    }
}

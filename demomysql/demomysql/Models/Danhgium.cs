using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Danhgium
    {
        public Danhgium()
        {
            Nguoidungs = new HashSet<Nguoidung>();
        }

        public int Madanhgia { get; set; }
        public int? Manguoidung { get; set; }
        public int? Sosao { get; set; }
        public DateTime? Ngaydanhgia { get; set; }

        public virtual Nguoidung ManguoidungNavigation { get; set; }
        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Giaohang
    {
        public Giaohang()
        {
            Donhangs = new HashSet<Donhang>();
        }

        public int Magiaohang { get; set; }
        public string Tennguoigiao { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public string Sdt { get; set; }
        public string Xacnhan { get; set; }

        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}

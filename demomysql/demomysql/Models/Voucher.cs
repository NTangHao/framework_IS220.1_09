using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Voucher
    {
        public Voucher()
        {
            Donhangs = new HashSet<Donhang>();
        }

        public int Mavoucher { get; set; }
        public string Tenma { get; set; }
        public DateTime? Ngaybd { get; set; }
        public DateTime? Ngaykt { get; set; }
        public double? Tyle { get; set; }
        public string Trangthai { get; set; }

        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
            Donhangs = new HashSet<Donhang>();
        }

        public int Idtransaction { get; set; }
        public string Tinhtrang { get; set; }
        public string Mota { get; set; }

        public virtual ICollection<Donhang> Donhangs { get; set; }
    }
}

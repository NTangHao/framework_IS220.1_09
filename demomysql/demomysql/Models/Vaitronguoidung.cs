using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Vaitronguoidung
    {
        public Vaitronguoidung()
        {
            Nguoidungs = new HashSet<Nguoidung>();
        }

        public int Maquyen { get; set; }
        public string Tenquyen { get; set; }

        public virtual ICollection<Nguoidung> Nguoidungs { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Nguoidung
    {
        public Nguoidung()
        {
            Binhluans = new HashSet<Binhluan>();
            Danhgia = new HashSet<Danhgium>();
            Donhangs = new HashSet<Donhang>();
            Tintucs = new HashSet<Tintuc>();
        }

        public int Manguoidung { get; set; }
        public int? Madanhgia { get; set; }
        public int Maquyen { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordReset { get; set; }
        public string Hoten { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Email { get; set; }
        public DateTime? Ngaytao { get; set; }
        public DateTime? Ngaysua { get; set; }
        public string Vaitro { get; set; }
        public bool? Trangthai { get; set; }
        public string Dienthoai { get; set; }

        public virtual Danhgium MadanhgiaNavigation { get; set; }
        public virtual Vaitronguoidung MaquyenNavigation { get; set; }
        public virtual ICollection<Binhluan> Binhluans { get; set; }
        public virtual ICollection<Danhgium> Danhgia { get; set; }
        public virtual ICollection<Donhang> Donhangs { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}

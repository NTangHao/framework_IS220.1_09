using System;
using System.Collections.Generic;

#nullable disable

namespace demomysql.Models
{
    public partial class Contact
    {
        public int Malh { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Noidung { get; set; }
        public string Tinhtrangdon { get; set; }
        public DateTime? Ngaygui { get; set; }
    }
}

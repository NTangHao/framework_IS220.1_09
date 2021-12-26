using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace demomysql.Models
{
    public partial class Contact
    {
        public int Malh { get; set; }
        [Required(ErrorMessage = "Họ tên không được trống")]
        public string Hoten { get; set; }
        [Required(ErrorMessage = "Email không được trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail không hợp lệ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Nội dung không được trống")]
        public string Noidung { get; set; }
        public string Tinhtrangdon { get; set; }
        public DateTime? Ngaygui { get; set; }
    }
}

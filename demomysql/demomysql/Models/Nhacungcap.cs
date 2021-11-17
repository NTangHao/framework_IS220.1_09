using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace demomysql.Models
{
    public partial class Nhacungcap
    {
        [DisplayName("Mã nhà cung cấp")]
        public int Mancc { get; set; }
        [DisplayName("Tên nhà cung cấp")]
        public string Tenncc { get; set; }
        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; }
        [DisplayName("Thành phố")]
        public string Thanhpho { get; set; }
        [DisplayName("Sđt")]
        public string Sdt { get; set; }
        [DisplayName("Tình trạng")]
        public byte? Tinhtrangxacnhan { get; set; }
    }
}

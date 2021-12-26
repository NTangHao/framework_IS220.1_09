using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.Models
{
    public class SendMailDto
    {
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Mailto { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Tiêu đề")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Nội dung")]
        public string Message { get; set; }
    }
}

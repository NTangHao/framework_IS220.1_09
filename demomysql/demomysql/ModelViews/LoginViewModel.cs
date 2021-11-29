using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace demomysql.ModelViews
{
    public class LoginViewModel
    {
        [MaxLength(100)]
        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [Display(Name ="Địa chỉ Email")]
        public string Username { get; set; }


        [MinLength(5,ErrorMessage ="Mật khẩu ít nhất 5 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        public string Paswword { get; set; }
    }
}

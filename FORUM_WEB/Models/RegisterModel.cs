using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FORUM_WEB.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tài khoản")]
        public string TenDangNhap { set; get; }
        [Required(ErrorMessage = "Bạn cần nhập mật khẩu")]
        [MinLength(6,ErrorMessage = "Mật khẩu ít nhất 6 kí tự !")]
        public string MatKhau { set; get; }
    }
}
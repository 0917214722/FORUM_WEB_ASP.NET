using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FORUM_WEB
{
    [Serializable]
    public class UserLogin
    {
        public string TenDangNhap { set; get; }
        public string MatKhau { set; get; }
        public string Avatar { set; get; }
    }
}
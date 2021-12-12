using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FORUM_WEB.Models
{
    public class ThreadModel
    {
        [Required(ErrorMessage = "Bạn cần nhập tiêu đề")]
        public string TieuDe { set; get; }
        [Required(ErrorMessage = "Bạn cần nội dung")]
        /*[AllowHtml]*/
        public string NoiDung { set; get; }
        public DateTime NgayDangBai { set; get; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FORUM_WEB.Models
{
    public class CommentModel
    {
        [Required(ErrorMessage = "Bạn cần nhập nội dung của bình luận !")]
        public string NoiDung { set; get; }
        public DateTime NgayBinhLuan { set; get; }

    }
}
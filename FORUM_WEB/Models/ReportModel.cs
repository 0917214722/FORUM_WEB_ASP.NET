using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace FORUM_WEB.Models
{
    public class ReportModel
    {
        [Required(ErrorMessage = "Nội dung không được để trống !")]
        public string NoiDung { set; get; }
    }
}
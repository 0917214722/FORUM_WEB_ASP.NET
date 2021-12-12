using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Models;
using FORUM_WEB.Models.FrameWork;
namespace FORUM_WEB.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            if (ModelState.IsValid)
            {
                var check = db.TaiKhoan.Count(x => x.TenDangNhap == model.TenDangNhap);
                if (check >= 1)
                {
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!");
                    return View(model);
                }
                var user = new TaiKhoan()
                {
                    TenDangNhap = model.TenDangNhap,
                    MatKhau = model.MatKhau,
                    Roll = 1,
                    Avatar = "photo-1637548739071-7c24bbcab218.png",
                    NgayGiaNhap = DateTime.Now
                };
                ModelState.AddModelError("", "Đăng kí thành công !");
                db.TaiKhoan.Add(user);
                db.SaveChanges();
            }
            return View(model);
        }
    }
}
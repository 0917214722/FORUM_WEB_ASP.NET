using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Common;
using FORUM_WEB.Areas.Admin.Data;
namespace FORUM_WEB.Areas.Admin.Controllers
{
    public class Admin_LoginController : Controller
    {
        // GET: Admin/Admin_Login
        public ActionResult Admin_Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session[CommonSession.ADMIN_LOGIN] = null;
            return RedirectToAction("Admin_Login", "Admin_Login");
        }
        [HttpPost]
        public ActionResult Admin_Login(Admin_LoginModel model)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            if (ModelState.IsValid)
            {
                var findAdmin = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap).FirstOrDefault();
                var adminSession = new AdminLogin();
                adminSession.TenDangNhap = model.TenDangNhap;
                adminSession.MatKhau = model.MatKhau;
                if (findAdmin != null)
                {
                    adminSession.Avatar = findAdmin.Avatar;
                }
                var res = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap && x.MatKhau == model.MatKhau && x.Roll == 0).Count();
                if (res > 0)
                {
                    Session.Add(CommonSession.ADMIN_LOGIN, adminSession);
                    return RedirectToAction("Index", "TaiKhoans");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc tài khoản khum đúng!");
                }
            }
            return View(model);
        }
    }
}
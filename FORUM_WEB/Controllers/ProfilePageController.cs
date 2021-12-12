using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Models.FrameWork;
using FORUM_WEB.Models;
namespace FORUM_WEB.Controllers
{
    public class ProfilePageController : Controller
    {
        // GET: ProfilePage
        public ActionResult ProfileUser(string tenDangNhap)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            var user = db.TaiKhoan.Where(x => x.TenDangNhap == tenDangNhap).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult ProfileUser(LoginModel model, string tenDangNhap)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            var session = (UserLogin)Session[FORUM_WEB.Common.CommonSession.USER_LOGIN];
            var f = Request.Files["image"];
            string path = Server.MapPath("~/Asset/img/" + f.FileName);
            f.SaveAs(path);
            var update = db.TaiKhoan.FirstOrDefault(x => x.TenDangNhap == session.TenDangNhap);
            update.Avatar = f.FileName;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
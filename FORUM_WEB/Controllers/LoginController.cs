using FORUM_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Common;
namespace FORUM_WEB.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        /*[HttpPost]*/
        /*public ActionResult Login(string username, string password)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            var userName = username;
            var passWord = password;
            var res = db.TaiKhoan.SingleOrDefault(x => x.TenDangNhap == userName && x.MatKhau == passWord);
            if(res != null)
            {
                Session ["user"] = res;
                return RedirectToAction("Index","HomePage");
            }
            else
            {
                return View();
            }
            
        }*/
        public ActionResult Logout()
        {
            Session[CommonSession.USER_LOGIN] = null;
            return RedirectToAction("Login", "Login");
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            if (ModelState.IsValid)
            {
                var findUser = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap).FirstOrDefault();
                var userSession = new UserLogin();
                userSession.TenDangNhap = model.TenDangNhap;
                userSession.MatKhau = model.MatKhau;
                if (findUser != null)
                {
                    userSession.Avatar = findUser.Avatar;
                }
                var res = db.TaiKhoan.Where(x => x.TenDangNhap == model.TenDangNhap && x.MatKhau == model.MatKhau).Count();
                if (res > 0)
                {
                    Session.Add(CommonSession.USER_LOGIN, userSession);
                    return RedirectToAction("Index", "HomePage");
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
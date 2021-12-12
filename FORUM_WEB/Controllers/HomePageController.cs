using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace FORUM_WEB.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            var session = (UserLogin)Session[FORUM_WEB.Common.CommonSession.USER_LOGIN];
            if (session == null)
            {
                return RedirectToAction("Login", "Login");
            }
            var lst = new List<Models.FrameWork.ChuDe>();
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            lst = db.ChuDe.ToList();
            return View(lst);
        }
        public ActionResult MessageCount(int id)
        {
            /*var lst = new List<Models.FrameWork.BaiDang>();*/
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            var lst = db.BinhLuan.Where(x => x.ID_BinhLuan == id).Count();
            return PartialView(lst);
        }
    }
}
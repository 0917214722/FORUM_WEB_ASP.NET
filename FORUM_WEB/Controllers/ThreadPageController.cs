using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FORUM_WEB.Controllers
{
    public class ThreadPageController : Controller
    {
        // GET: ThreadPage
        public ActionResult Index(int id)
        {
            ViewBag.id_cd = id;
            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            var lst = new List<Models.FrameWork.BaiDang>();
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            lst = db.BaiDang.Where(x => x.ID_ChuDe == id).ToList();
            return View(lst);
        }
    }
}
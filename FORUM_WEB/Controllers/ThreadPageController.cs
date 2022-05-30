using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
namespace FORUM_WEB.Controllers
{
    public class ThreadPageController : Controller
    {
        // GET: ThreadPage
        public ActionResult Index(int id, int? page)
        {
            /*
            ViewBag.returnUrl = Request.UrlReferrer.ToString();
            var lst = new List<Models.FrameWork.BaiDang>();
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            lst = db.BaiDang.Where(x => x.ID_ChuDe == id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return View(lst);*/
            ViewBag.id_cd = id;
            if (page == null) page = 1;
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
            var lst = new List<Models.FrameWork.BaiDang>();
            lst = db.BaiDang.Where(x => x.ID_ChuDe == id).ToList();
            return View((lst.ToPagedList(pageNumber, pageSize)));
        }
    }
}
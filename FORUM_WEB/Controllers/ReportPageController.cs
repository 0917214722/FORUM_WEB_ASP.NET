using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Models;
using FORUM_WEB.Models.FrameWork;
namespace FORUM_WEB.Controllers
{
    public class ReportPageController : Controller
    {
        // GET: ReportPage
        public ActionResult ReportPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ReportPage(ReportModel model)
        {
            if (ModelState.IsValid)
            {
                Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
                var session = (UserLogin)Session[FORUM_WEB.Common.CommonSession.USER_LOGIN];
                var rp = new BaoCao()
                {
                    NoiDung = model.NoiDung,
                    NguoiBaoCao = session.TenDangNhap
                };
                db.BaoCao.Add(rp);
                db.SaveChanges();
                return RedirectToAction("ReportNoti","ReportPage");
            }
            return View();
        }
        public ActionResult ReportNoti()
        {
            return View();
        }
    }
        
}
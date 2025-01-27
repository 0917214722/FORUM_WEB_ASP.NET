﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FORUM_WEB.Models.FrameWork;
using FORUM_WEB.Models;
namespace FORUM_WEB.Controllers
{
    public class PostPageController : Controller
    {
        int id;
        Models.FrameWork.FORUM_WEBEntities db = new Models.FrameWork.FORUM_WEBEntities();
        // GET: PostPage
        public ActionResult PostPage(int id)
        {
            this.id = id;
            var post = db.BaiDang.Where(x => x.ID_BaiDang == id).FirstOrDefault();
            return View(post);
        }
        public ActionResult Comment(int id)
        {
            var lst = new List<FORUM_WEB.Models.FrameWork.BinhLuan>();
            lst = db.BinhLuan.Where(x => x.ID_BaiDang == id).ToList();
            return PartialView(lst);
        }
        public ActionResult PostComment()
        {

            return PartialView();
        }
        [HttpPost]
        public ActionResult PostComment(CommentModel model, int id)
        {
            if (ModelState.IsValid) { 
                var session = (UserLogin)Session[FORUM_WEB.Common.CommonSession.USER_LOGIN];
                var comment = new BinhLuan()
                {
                    NoiDung = model.NoiDung,
                    TenDangNhap = session.TenDangNhap,
                    NgayBinhLuan = DateTime.Now,
                    ID_BaiDang = id
                };
                db.BinhLuan.Add(comment);
                db.SaveChanges();
                return Redirect(Request.UrlReferrer.ToString());
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
        public ActionResult PostThread()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PostThread(ThreadModel model, int id)
        {
            if (ModelState.IsValid) { 
                var session = (UserLogin)Session[FORUM_WEB.Common.CommonSession.USER_LOGIN];
                var thread = new BaiDang()
                {
                    TieuDe = model.TieuDe,
                    NoiDung = model.NoiDung,
                    ID_ChuDe = id,
                    TenDangNhap = session.TenDangNhap,
                    NgayDangBai = DateTime.Now
                };
                db.BaiDang.Add(thread);
                db.SaveChanges();
                return RedirectToAction("Index","ThreadPage",new {id = id});
            }
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiaSeCode_TTV.Models;

namespace ChiaSeCode_TTV.Controllers
{
    public class HomeController : Controller
    {
        DataDemoShareCodeEntities2 db = new DataDemoShareCodeEntities2();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Demoes.Where(n => n.TrangChu == 1).ToList());
        }
        public PartialViewResult DanhMuc()
        {
            return PartialView(db.DanhMucs.ToList());
        }
        public PartialViewResult danhmucphanloai()
        {
            return PartialView(db.PhanLoaiDanhMucs.ToList());
        }
        public PartialViewResult noibathome()
        {
            return PartialView(db.Demoes.Where(n => n.NoiBat == 2).ToList());
        }
        public PartialViewResult CodeMoi()
        {
            var demo = db.Demoes.Take(3).ToList();
            return PartialView(demo);
        }
        public PartialViewResult CodeBan()
        {
            var demo = db.BanCodes.Take(3).ToList();
                return PartialView(demo);
        }
        public ViewResult xemchitietdemo(int MaDemo)
        {
            Demo demo = db.Demoes.SingleOrDefault(n => n.MaDemo == MaDemo);
            if (demo == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(demo);
        }



        //theo danh muc
        public ViewResult DemoDanhMuc(int MaDanhMuc=0)
        {
            DanhMuc dm = db.DanhMucs.SingleOrDefault(n => n.MaDanhMuc == MaDanhMuc);
            if(dm == null)
                {
                Response.StatusCode = 404;
                return null;
                }
            List<Demo> lstDemo = db.Demoes.Where(n => n.MaDanhMuc == MaDanhMuc).ToList();
            if(lstDemo.Count==0)
            {
                ViewBag.Demo = "Không có Demo nào";
            }
            return View(lstDemo);

        }
    }
}
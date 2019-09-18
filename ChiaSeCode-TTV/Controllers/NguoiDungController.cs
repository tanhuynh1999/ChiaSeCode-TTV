using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChiaSeCode_TTV.Models;

namespace ChiaSeCode_TTV.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        DataDemoShareCodeEntities2 db = new DataDemoShareCodeEntities2();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DangKy(NguoiDung nd)
        {
           if(ModelState.IsValid)
            {
                db.NguoiDungs.Add(nd);
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();
            NguoiDung nd = db.NguoiDungs.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (nd != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành cônng vào TTVCODE.COM";
                Session["TaiKhoan"] = nd;
                return View();
            }
            ViewBag.ThongBao = "Đăng nhập thất bại";
            return View();
        }
    }
}
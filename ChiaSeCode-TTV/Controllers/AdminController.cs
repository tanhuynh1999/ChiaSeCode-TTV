using ChiaSeCode_TTV.Models;
using PagedList;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ChiaSeCode_TTV.Controllers
{
    public class AdminController : Controller
    {
        DataDemoShareCodeEntities2 db = new DataDemoShareCodeEntities2();
        // GET: Admin
        public ActionResult Index(int? page)
        {
            int trang = 10;
            int pageNumber = (page ?? 1);
            return View(db.Demoes.ToList().OrderBy(n => n.TenDemo).ToPagedList(pageNumber, trang));
        }

        [HttpGet]
        public ActionResult add()
        {
            ViewBag.DM = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.TenDanhMuc), "MaDanhMuc", "TenDanhMuc");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(Demo demo, HttpPostedFileBase fileuUpload)
        {


            ViewBag.DM = new SelectList(db.DanhMucs.ToList().OrderBy(n => n.TenDanhMuc), "MaDanhMuc", "TenDanhMuc");

            if (fileuUpload == null)
            {
                ViewBag.ThongBao = "Chọn hình ảnh";
                return View();
            }

            if (ModelState.IsValid)
            {
                //Save file name
                var ff = Path.GetFileName(fileuUpload.FileName);
                //Duong dẫn
                var path = Path.Combine(Server.MapPath("~/img"), ff);
                //kiem tra ton tai
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                }
                else
                {
                    fileuUpload.SaveAs(path);
                }
                demo.Anh = fileuUpload.FileName;
                db.Demoes.Add(demo);
                db.SaveChanges();
            }
            return View();

        }



    }
}
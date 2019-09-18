using System.Linq;
using System.Web.Mvc;
using ChiaSeCode_TTV.Models;
using PagedList;
using PagedList.Mvc;
namespace ChiaSeCode_TTV.Controllers
{
    public class QuanLyController : Controller
    {
        // GET: QuanLy
        DataDemoShareCodeEntities2 db = new DataDemoShareCodeEntities2();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult all(int? page)
        {
            int sohien = 10;
            int pageNumber = (page ?? 1);

            return View(db.Demoes.Where(n=>n.TrangChu==1).OrderBy(n=>n.NgonNgu).ToPagedList(pageNumber, sohien));
        }
        
    }
}
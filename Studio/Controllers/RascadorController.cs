using Studio.Models.Transaccional.Entities;
using System.Linq;
using System.Web.Mvc;

namespace Studio.Controllers
{
    public class RascadorController : Controller
    {
        //
        // GET: /Rascador/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return View();
        }

        public ActionResult GetAlbumsForm(string q)
        {
            //uso mustage
            MusicStoreEntities db = new MusicStoreEntities();
            var albums = db.Albums.Where(a => a.Title.Contains(q)).ToList().Take(5);
            return Json(albums, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAlbumsScroll(string q, int Id)
        {
            //uso mustage
            MusicStoreEntities db = new MusicStoreEntities();
            var albums = db.Albums.Where(a => a.Title.Contains(q) && a.Id>Id).ToList().Take(5);
            if (albums.Count()==0)
                return Json(null, JsonRequestBehavior.AllowGet);

            return Json(albums, JsonRequestBehavior.AllowGet);
        }
    }
}
using Studio.Models.Transaccional.Entities;
using Studio.Models.Transaccional.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public ActionResult Index()
        {
            ViewBag.Message = "Modifique esta plantilla para poner en marcha su aplicación ASP.NET MVC.";
            MusicStoreEntities db = new MusicStoreEntities();
            ViewBag.Inicio = 50; ViewBag.Fin = 100; // Siguiente en la lista
                            
            try
               {
                   ViewBag.Albums = (from a in db.Albums 
                                     orderby a.Id ascending
                                     select a).Take(50).ToList();
               }
               catch (Exception ex)
               {
                   log.Debug("Debug error logging", ex);
                   log.Info("Info error logging", ex);
                   log.Warn("Warn error logging", ex);
                   log.Error("Error error logging", ex);
                   log.Fatal("Fatal error logging", ex);
               }
            return View();
        }


        public ActionResult Siguiente(int Inicio, int Fin)
        {
            using(MusicStoreEntities db = new MusicStoreEntities())
            {
                List<Album> Albums = (from a in db.Albums orderby a.Id ascending select a).Take(Fin).ToList();
                Albums.RemoveRange(0, Inicio - 1);
                return View(Albums);
            }
            
        }

        [HttpGet]
        public ActionResult About()
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                ViewBag.Albums = (from r in db.Albums.Include("Artist").Include("Genre") select r.Title).ToList();
                ViewBag.Genre = (from r in db.Genres select r.Name).ToList();
                ViewBag.Artist = (from r in db.Artists select r.Name).ToList();
                return View();
            }
        }

        [HttpPost]
        public string About(Album album)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                if(album!=null)
                    return "Thank you " + album.Title + ". Record Saved.";
                else
                    return "Please complete the form.";
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Página de contacto.";

            return View();
        }

        public string TellMeDate()
        {
            return DateTime.Now.ToString();
        }

        public string WelcomeMsg(string input)
        {
            if (!String.IsNullOrEmpty(input))
                return "Please welcome " + input + ".";
            else
                return "Please enter your name.";
        }

        public JsonResult AlbumsList(string Id)
        {
            using (MusicStoreEntities db = new MusicStoreEntities())
            {
                List<Album> Albums = (from a in db.Albums.Include("Artist")
                                      where a.Title.Contains(Id) 
                                      orderby a.Id ascending select a).ToList();
                return Json(Albums, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public string SubmitSubscription(string Name, string Address)
        {
            if (!String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Address))
                //TODO: Save the data in database
                return "Thank you " + Name + ". Record Saved.";
            else
                return "Please complete the form.";

        }

        public ActionResult DailyDeal()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            var album = db.Albums.Include("Artist").OrderBy(a => a.Price).First();
            return PartialView("_DailyDeal", album);
        }

        public ActionResult ArtistSearch(string q)
        {
            //vista parcial
            MusicStoreEntities db = new MusicStoreEntities();
            var artists = db.Artists.Where(a=>a.Name.Contains(q)).ToList();
            return PartialView("ArtistSearch",artists);
        }

        public ActionResult ArtistSearchNEW(string q)
        {
            //uso mustage
            MusicStoreEntities db = new MusicStoreEntities();
            var artists = db.Artists.Where(a => a.Name.Contains(q)).ToList();
            return Json(artists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AjaxForms()
        {
            return View();
        }

        public ActionResult ClientValidation()
        {
            return View();
        }

        public ActionResult Autocomplete()
        {
            return View();
        }

        public ActionResult QuickSearch(string term)
        {
            MusicStoreEntities db = new MusicStoreEntities();
            var artists = db.Artists.Where(a => a.Name.Contains(term)).ToList().Select(a => new { value = a.Name });
            return Json(artists, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchForm()
        {
            return View();
        }
    }

}

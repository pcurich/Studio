using Studio.Areas.Seguridad.Models;
using Studio.Models.Seguridad.Entities;
using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio.Areas.Seguridad.Controllers
{
    public class ComponentesController : Controller
    {
        //
        // GET: /Seguridad/Componentes/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAplicaciones()
        {
            Security sc = new Security();
            Element padre = sc.Elements.Where(n => n.Name == "Aplicacion").FirstOrDefault();
            List<Element> json = new List<Element>();
            json.Add(new Element { Id = 0, Name = "" });
            json.AddRange(sc.Elements.Where(p => p.RelativeId == padre.Id).ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetElementos(string type, string id)
        {
            Security sc = new Security();
            int Id=  Convert.ToInt16(id);
            List<Element> json = new List<Element>();
            json.Add(new Element { Id = 0, Name = type });
            json.AddRange(sc.Elements.Where(p => p.RelativeId == Id).ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevoElemento(string Q)
        {
            Security sc = new Security();
            //http://mvc3only.blogspot.com/2012/04/aspnet-mvc3-ajax-form-submission-simple.html
            //http://www.deliveron.com/blog/post/creating-a-cascading-dropdown-in-aspnet-mvc-3-and-jquery.aspx
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo()
        {
            Security sc = new Security();
            var model = new ViewElement();
            Element padre = sc.Elements.Where(n => n.Name == "Aplicacion").FirstOrDefault();
            List<Element> json = new List<Element>();
            json.Add(new Element { Id = 0, Name = "" });
            json.AddRange(sc.Elements.Where(p => p.RelativeId == padre.Id).ToList());
            model.Aplicacion = new SelectList(json, "Id", "Name");
            return View(model);
        }

    }
}

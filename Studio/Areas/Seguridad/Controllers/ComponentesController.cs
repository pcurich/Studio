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
        public ActionResult NuevoElemento(string Idn1, string Idn2, string Idn3, string Idn4, string Nombre, string Resumen, string Active)
        {
            Security sc = new Security();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

    }
}

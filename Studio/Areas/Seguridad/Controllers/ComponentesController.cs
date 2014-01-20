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
            var json = sc.Elements.Where(p => p.RelativeId == padre.Id).ToList();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetAreas(string id)
        {
            Security sc = new Security();
            int Id=  Convert.ToInt16(id);// Aplicacion -> Area
            var json = sc.Elements.Where(p => p.RelativeId == Id).ToList();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetControlador(string id)
        {
            Security sc = new Security();
            int Id = Convert.ToInt16(id);// Area -> Controlador
            var json = sc.Elements.Where(p => p.RelativeId == Id).ToList();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetVista(string id)
        {
            Security sc = new Security();
            int Id = Convert.ToInt16(id);// Area -> Controlador
            var json = sc.Elements.Where(p => p.RelativeId == Id).ToList();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevaAplicacion(Element elemento)
        {
            Security sc = new Security();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevaArea(Element elemento)
        {
            Security sc = new Security();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevoController(Element elemento)
        {
            Security sc = new Security();
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevoVista(Element elemento)
        {
            Security sc = new Security();
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}

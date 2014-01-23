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
            json.Add(new Element { Id = 0, Name = "" });
            json.AddRange(sc.Elements.Where(p => p.RelativeId == Id).ToList());
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NuevoElemento(ViewElement Model)
        {
            Security sc = new Security();
            //http://mvc3only.blogspot.com/2012/04/aspnet-mvc3-ajax-form-submission-simple.html
            //http://www.deliveron.com/blog/post/creating-a-cascading-dropdown-in-aspnet-mvc-3-and-jquery.aspx
            //http://forums.asp.net/t/1909055.aspx
            Element nuevo = new Element();
            nuevo.Name = Model.Nombre;
            nuevo.UsuarioCreacion = "system"; ;//User.Identity.Name;
            nuevo.UsuarioModificacion = "system";
            nuevo.FechaCreacion = DateTime.Now;
            nuevo.FechaModificacion = DateTime.Now;

            if (Model.Aplicacion == 0) //Se ingresa una aplicacion
            {
                nuevo.RelativeId = sc.Elements.Where(n => n.Name == "Aplicacion").FirstOrDefault().Id;
            }else
                if (Model.Area == 0)// se ingresa un area
                {
                    nuevo.RelativeId = Model.Aplicacion;
                }
                else
                    if (Model.Controller == 0)//se ingresa un controller
                    {
                        nuevo.RelativeId = Model.Area;
                    }
                    else//se ingresa una vista
                    {
                        nuevo.RelativeId = Model.Controller;
                    }
            sc.Elements.Add(nuevo);
            sc.SaveChanges();
            //return Json("Ok", JsonRequestBehavior.AllowGet);
            return RedirectToAction("Nuevo");
        }

        public ActionResult Nuevo()
        {
            Security sc = new Security();
            var model = new ViewElement();
            ViewBag.Aplicacion = new SelectList(new List<Element>() { new Element { Id = 0, Name = "" } }, "Id", "Name");
            ViewBag.Area = new SelectList(new List<Element>() { new Element { Id = 0, Name = "" } }, "Id", "Name");
            ViewBag.Controller = new SelectList(new List<Element>() { new Element { Id = 0, Name = "" } }, "Id", "Name");
            ViewBag.Vista = new SelectList(new List<Element>() { new Element { Id = 0, Name = "" } }, "Id", "Name");
            return View(model);
        }

        [HttpGet]
        public ActionResult GetNestedList()
        {
            Security sc = new Security();
            List<NestedList> arbol = new List<NestedList>();

            var elementos=sc.Elements.Where(r=>r.RelativeId>0).ToList();
            foreach(Element aplicaciones in elementos)
            {
                NestedList nodoAplicacion = new NestedList();
                nodoAplicacion.ul = aplicaciones.Name;
                var elementoAplicaciones=sc.Elements.Where(e=>e.RelativeId==aplicaciones.Id).ToList();
                List<NestedList> ArbolArea = new List<NestedList>();

                foreach(Element areas in elementoAplicaciones)
                {
                    NestedList nodoArea = new NestedList();
                    nodoArea.ul = areas.Name;
                    var elementoAreas=sc.Elements.Where(e=>e.RelativeId==areas.Id).ToList();
                    List<NestedList> ArbolControllers = new List<NestedList>();

                    foreach(Element controllers in elementoAreas )
                    {
                        NestedList nodoController = new NestedList();
                        nodoController.ul = controllers.Name;
                        var elementocontrollers=sc.Elements.Where(e=>e.RelativeId==controllers.Id).ToList();
                        List<NestedList> ArbolVistas = new List<NestedList>();

                        foreach(Element vistas in elementoAreas )
                        {
                            NestedList nodoVista = new NestedList();
                            nodoVista.ul = vistas.Name;
                            var elementoElemento=sc.Elements.Where(e=>e.RelativeId==vistas.Id).ToList();
                            List<NestedList> ArbolElementos = new List<NestedList>();
                            foreach(Element elemento in elementoElemento )
                            {
                                NestedList nodoElemento = new NestedList();
                                nodoElemento.ul = elemento.Name;
                                ArbolElementos.Add(nodoElemento);
                            }
                            nodoVista.children = ArbolElementos;
                            ArbolVistas.Add(nodoVista);
                        }
                        nodoController.children = ArbolVistas;
                        ArbolControllers.Add(nodoController);
                    }
                    nodoArea.children = ArbolControllers;
                    ArbolArea.Add(nodoArea);
                }
                nodoAplicacion.children = ArbolArea;
                arbol.Add(nodoAplicacion);
            }
            return Json(arbol,JsonRequestBehavior.AllowGet);
        }

    }
}

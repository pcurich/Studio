using Studio.Areas.Seguridad.Models;
using Studio.Models.Seguridad.Entities;
using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Script.Services;
using System.Web.Services;

namespace Studio.Areas.Seguridad.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Seguridad/Usuarios/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllNodes11(string id)
        {
            List<G_JSTree> G_JSTreeArray = new List<G_JSTree>();

            G_JSTree _G_JSTree = new G_JSTree();
            _G_JSTree.data = "x1";
            _G_JSTree.state = "closed";
            _G_JSTree.IdServerUse = 10;
            _G_JSTree.children = null;
            _G_JSTree.attr = new G_JsTreeAttribute { id = "10", selected = false };
            G_JSTreeArray.Add(_G_JSTree);

            G_JSTree _G_JSTree2 = new G_JSTree();
            var children =
                new G_JSTree[]
            {
                new G_JSTree { data = "x1-11", attr = new G_JsTreeAttribute { id = "201" } },
                new G_JSTree { data = "x1-12", attr = new G_JsTreeAttribute { id = "202" } },
                new G_JSTree { data = "x1-13", attr = new G_JsTreeAttribute { id = "203" } },
                new G_JSTree { data = "x1-14", attr = new G_JsTreeAttribute { id = "204" } },
            };
            _G_JSTree2.data = "x2";
            _G_JSTree2.IdServerUse = 20;
            _G_JSTree2.state = "closed";
            _G_JSTree2.children = children;
            _G_JSTree2.attr = new G_JsTreeAttribute { id = "20", selected = true };
            G_JSTreeArray.Add(_G_JSTree2);

            G_JSTree _G_JSTree3 = new G_JSTree();
            var children2 =
                new G_JSTree[]
            {
                new G_JSTree { data = "x2-11", attr = new G_JsTreeAttribute { id = "301" } },
                new G_JSTree { data = "x2-12", attr = new G_JsTreeAttribute { id = "302" }, children= new G_JSTree[]{new G_JSTree{data = "x2-21", attr = new G_JsTreeAttribute { id = "3011" }}} },
                new G_JSTree { data = "x2-13", attr = new G_JsTreeAttribute { id = "303" } },
                new G_JSTree { data = "x2-14", attr = new G_JsTreeAttribute { id = "304" } },
            };
            _G_JSTree3.data = "x3";
            _G_JSTree3.state = "closed";
            _G_JSTree3.IdServerUse = 30;
            _G_JSTree3.children = children2;
            _G_JSTree3.attr = new G_JsTreeAttribute { id = "30", selected = true };
            G_JSTreeArray.Add(_G_JSTree3);
            return Json(G_JSTreeArray, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsuarios(string id)
        {
            if (id.Substring(0, 1).CompareTo("r") == 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            List<JsUsuarios> jsTree = new List<JsUsuarios>();
            Security sc = new Security();
            List<User> users = sc.Users.Include("Rol").ToList();
            foreach (User u in users)
            {
                JsUsuarios js = new JsUsuarios();
                js.data = u.UserName;
                js.state = "closed";
                js.IdServerUse = u.Id;
                js.attr = new JsUsuariosAttribute { id="u"+u.Id.ToString(), selected=false };
                js.icons = "glyphicon glyphicon-user";

                List<Rol> roles = sc.Rols.Where(r => r.Id == u.RolId).ToList();
                if (roles.Count > 0)
                {

                    for (int j = 0; j < roles.Count; j++)
                    {
                        JsUsuarios children = new JsUsuarios();
                        children.data = roles[j].Name;
                        children.attr = new JsUsuariosAttribute { id = "r" + roles[j].Id, selected = false };
                        children.state = "closed";
                        children.IdServerUse = roles[j].Id;
                        children.icons = "glyphicon glyphicon-user";
                        children.children = null;
                        js.children.Add(children);
                    }

                }
                else
                {
                    js.children = null;
                }
                jsTree.Add(js);
            }
            return Json(jsTree, JsonRequestBehavior.AllowGet);
        }

    }
}

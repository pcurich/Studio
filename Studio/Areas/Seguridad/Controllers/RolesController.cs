using Studio.Areas.Seguridad.Models;
using Studio.Models.Seguridad.Entities;
using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Studio.Areas.Seguridad.Controllers
{
    public class RolesController : Controller
    {
        //
        // GET: /Seguridad/Roles/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUsuarios(string id)
        {
            List<JsTree> jsTree = new List<JsTree>();
            Security sc = new Security();
            List<User> users = sc.Users.Include("Rol").ToList();
            foreach (User u in users)
            {
                List<Rol> roles = sc.Rols.Where(r => r.Id == u.RolId).ToList();

                JsTree js = new JsTree(roles.Count);
                js.id = u.Id.ToString();
                js.text = u.UserName;
                js.icon = "glyphicon glyphicon-user";
                js.state = new State { disabled = false, opened = false, selected = false };

                if (roles.Count > 0)
                {
                    for (int j = 0; j < roles.Count; j++)
                    {
                        js.children[j] = roles[j].Name;
                    }
                }
                jsTree.Add(js);
            }
            return Json(jsTree, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetUsuario(string id)
        {
            try
            {
                int Id = Convert.ToInt16(id);
                Security sc = new Security();
                User user = sc.Users.Include("Rol").Where(u => u.Id == Id).FirstOrDefault();
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new User {UserName="",Password="" }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult AjaxHandle(JQueryDataTableParamModel param)
        {
            #region seacrch
            var idSearchable = Convert.ToString(Request["sSearch_0"]);
            var nameFilter = Convert.ToString(Request["sSearch_1"]);
            var addressFilter = Convert.ToString(Request["sSearch_2"]);
            var townFilter = Convert.ToString(Request["sSearch_3"]);

            var isIDSearchable = Convert.ToBoolean(Request["bSearchable_0"]);
            var isNameSearchable = Convert.ToBoolean(Request["bSearchable_1"]);
            var isAddressSearchable = Convert.ToBoolean(Request["bSearchable_2"]);
            var isTownSearchable = Convert.ToBoolean(Request["bSearchable_3"]);
            #endregion

            var allCompanies = DataRepository.GetCompanies();
            IEnumerable<Company> filteredCompanies;

            #region filtros
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                filteredCompanies = DataRepository.GetCompanies()
                         .Where(c => c.Name.Contains(param.sSearch)
                                     ||
                          c.Address.Contains(param.sSearch)
                                     ||
                          c.Town.Contains(param.sSearch));
            }
            else
            {
                filteredCompanies = allCompanies
                    .Skip(param.iDisplayStart)
                    .Take(param.iDisplayLength);
            }
            #endregion

            #region Ordenar


            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            var isIdSortable = Convert.ToBoolean(Request["bSortable_0"]);
            var isNameSortable = Convert.ToBoolean(Request["bSortable_1"]);
            var isAddressSortable = Convert.ToBoolean(Request["bSortable_2"]);
            var isTownSortable = Convert.ToBoolean(Request["bSortable_3"]);
            
            sortColumnIndex = Convert.ToBoolean(Request["bSortable_0"]) == true ? 0 :
                Convert.ToBoolean(Request["bSortable_1"]) == true ? 1 :
                Convert.ToBoolean(Request["bSortable_2"]) == true ? 2 : 3;

            Func<Company, string> orderingFunction = (c => sortColumnIndex == 1 ? c.Name :
                                                        sortColumnIndex == 2 ? c.Address :
                                                        c.Town);
            var sortDirection = Request["sSortDir_0"]; // asc or desc


            if (sortDirection == "asc")
                filteredCompanies = filteredCompanies.OrderBy(orderingFunction);
            else
                filteredCompanies = filteredCompanies.OrderByDescending(orderingFunction);
            #endregion

            var displayedCompanies = filteredCompanies;
            var result = from c in displayedCompanies
                         select new[] { Convert.ToString(c.ID), c.Name, c.Address, c.Town };
            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = allCompanies.Count(),
                iTotalDisplayRecords = filteredCompanies.Count(),
                aaData = result
            },JsonRequestBehavior.AllowGet);

            //return Json(new
            //{
            //    sEcho = param.sEcho,
            //    iTotalRecords = 97,
            //    iTotalDisplayRecords = 3,
            //    aaData = new List<string[]>() {
            //        new string[] {"1", "Microsoft", "Redmond", "USA"},
            //        new string[] {"2", "Google", "Mountain View", "USA"},
            //        new string[] {"3", "Gowi", "Pancevo", "Serbia"}
            //        }
            //},JsonRequestBehavior.AllowGet);
        }
    }

    public class JQueryDataTableParamModel
    {
        /* The integer value that is used by DataTables for synchronization purpose. On each call sent to the server-side page,
           the DataTables plug-in sends the sequence number in the sEcho parameter. The same value has to be returned in response because
           DataTables uses this for synchronization and matching requests and responses.*/

        public string sEcho { get; set; }

        public string sSearch { get; set; }

        public int iDisplayLength { get; set; }

        public int iDisplayStart { get; set; }

        public int iColumns { get; set; }

        public int iSortingCols { get; set; }

        public string sColumns { get; set; }
    }
}
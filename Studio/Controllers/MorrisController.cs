using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Studio.Controllers
{
    public class MorrisController : Controller
    {
        //
        // GET: /Morris/

        public ActionResult Index()
        {
            //http://www.oesmith.co.uk/morris.js/lines.html
            //http://jsbin.com/uqawig/441/embed?javascript,live
            return View();
        }

    }
}

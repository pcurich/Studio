using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Studio.Controllers
{
    public class ThreeController : Controller
    {
        //
        // GET: /Three/

        public ActionResult Index()
        {
            //Request.UserAgent.IndexOf(device.Value, StringComparison.OrdinalIgnoreCase)

            return View(GeoLocate(" 200.62.140.30"));
        }

        public Location GeoLocate(string ip)
        {
            const string API_KEY = "f93ac82965fd163e146151fbde0dd752bbb57c1a80e2542eb903667d6a220472";


            var url = "http://api.ipinfodb.com/v3/ip-city/?key={0}&ip={1}&format=xml";
            var doc = XDocument.Load(string.Format(url, API_KEY, ip));

            return new Location
            {
                countryCode = doc.Descendants("countryCode").First().Value,
                countryName = doc.Descendants("countryName").First().Value,
                regionName = doc.Descendants("regionName").First().Value,
                cityName = doc.Descendants("cityName").First().Value,
                zipCode = doc.Descendants("zipCode").First().Value,
                latitude = decimal.Parse(doc.Descendants("latitude").First().Value, CultureInfo.InvariantCulture),
                longitude = decimal.Parse(doc.Descendants("longitude").First().Value, CultureInfo.InvariantCulture)
            };
        }

    }
}

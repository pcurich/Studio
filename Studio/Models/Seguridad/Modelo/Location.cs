using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Modelo
{
    public class Location:DbAble
    {
        public string API_KEY { set; get; } 
        public string countryCode { set; get; }
        public string countryName { set; get; }
        public string regionName { set; get; }
        public string cityName { set; get; }
        public string zipCode { set; get; }
        public decimal latitude { set; get; }
        public decimal longitude { set; get; }
        public decimal timeZone { set; get; }
        
        public Location()
        {
            API_KEY="f93ac82965fd163e146151fbde0dd752bbb57c1a80e2542eb903667d6a220472";
        }
        
    }
}
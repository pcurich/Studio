using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Modelo
{
    public class Rol : DbAble
    {
        public string Name { get; set; }
        public List<License> Licenses { get;set; }
    }
}
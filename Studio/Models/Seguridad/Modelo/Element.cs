using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Modelo
{
    public class Element:DbAble
    {
        public int RelativeId { get; set; }
        public string Name { get; set; }
    }
}
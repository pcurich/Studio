using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Modelo
{
    public class License:DbAble
    {
        public string Name { get; set; } //Lectura Escritura Ninguno
        public List<Element> Elements { get; set; }
    }
}